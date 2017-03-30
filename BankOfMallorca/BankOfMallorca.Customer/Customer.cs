using System;

namespace BankOfMallorca.Customer
{
    public class Customer
    {
        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}