using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace BankOfMallorca.Account
{
    public class InMemoryAccountRepository : IAccountRepository
    {

        private static readonly IDictionary<Guid, Account> Accounts = new ConcurrentDictionary<Guid, Account>();

        public Account Save(Guid customerId )
        {
            var accountId = Guid.NewGuid();
            Account account = new Account(customerId, accountId);
            return account;
        }


    }
}