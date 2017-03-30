using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfMallorca.Account
{
    public class Account
    {
        public Account(Guid customerId,Guid  accountId)
        {
            CustomerId = customerId;
            AccountId = accountId;

            Saldo = 0;
        }

        public Guid CustomerId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Saldo { get; set; }
}
}
