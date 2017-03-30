using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfMallorca.Customer
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly IEventStore _eventStore;
        private static readonly IDictionary<Guid, Customer> Customers = new ConcurrentDictionary<Guid, Customer>();

        public InMemoryCustomerRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public async Task Save(Customer customer)
        {
            Customers.Add(customer.Id, customer);

            await _eventStore.Raise("CustomerCreated", new
            {
                customer.Id,
                customer.Name
            });
        }
    }
}