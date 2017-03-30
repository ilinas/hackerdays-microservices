using System;
using System.Collections.Generic;

namespace BankOfMallorca.Account
{
    public interface IAccountRepository
    {
        Account Save(System.Guid customerId);
        List<string> GetAccounts(Guid customerId);
    }
}