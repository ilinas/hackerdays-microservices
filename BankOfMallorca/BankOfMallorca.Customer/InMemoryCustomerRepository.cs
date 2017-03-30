using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BankOfMallorca.Customer
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private static readonly IDictionary<Guid, Customer> Customers = new ConcurrentDictionary<Guid, Customer>();

        public void Save(Customer customer)
        {
            Customers.Add(customer.Id, customer);
        }
    }
}