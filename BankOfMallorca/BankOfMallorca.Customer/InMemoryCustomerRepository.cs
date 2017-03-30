using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

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

        public void Save(Customer customer)
        {
            Customers.Add(customer.Id, customer);
            _eventStore.Raise("CustomerCreated", new
            {
                customer.Id,
                customer.Name
            });
        }
    }
}