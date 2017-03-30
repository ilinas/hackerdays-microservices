using System;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

namespace BankOfMallorca.Customer
{
    public class CustomerModule : NancyModule
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerModule(ICustomerRepository customerRepository) : base("/customers")
        {
            _customerRepository = customerRepository;

            Post("/", async (parameters, _) =>
            {
                var customerId = await CreateCustomer(this.Bind<CreateCustomerBindModel>());

                var response = (Response) customerId.ToString();
                response.StatusCode = HttpStatusCode.Created;
                return response;
            });
        }

        private async Task<Guid> CreateCustomer(CreateCustomerBindModel createCustomer)
        {
            var customerId = Guid.NewGuid();
            var customer = new Customer(customerId, createCustomer.Name);
            await _customerRepository.Save(customer);
            return customerId;
        }

        private class CreateCustomerBindModel
        {
            public string Name { get; set; }
        }
    }
}