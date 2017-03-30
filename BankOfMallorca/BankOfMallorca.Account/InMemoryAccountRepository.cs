using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
namespace BankOfMallorca.Account
{
    public class InMemoryAccountRepository : IAccountRepository
    {

        private static readonly IDictionary<Guid, List<Account>> Accounts = new ConcurrentDictionary<Guid, List<Account>>();

        public List<string> GetAccounts(Guid customerId)
        {
            if (Accounts.ContainsKey(customerId))
            {

                return Accounts[customerId].Select(x => x.AccountId.ToString()).ToList();
            }

            return new List<string>();

        }

        public Account Save(Guid customerId )
        {
            var accountId = Guid.NewGuid();
            Account account = new Account(customerId, accountId);

            if (!Accounts.ContainsKey(customerId)) {

                List<Account> accounts = new List<Account>();
                Accounts.Add(customerId, accounts);
            }
            Accounts[customerId].Add(account);
            return account;
        }



    }
}