using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BankOfMallorca.Account
{
    public class AccountModule : Nancy.NancyModule
    {

        public AccountModule(IAccountRepository repos) : base("/account")
        {
         
            Get("/{customerid}", (parameters) => {

                var customerId = (string)parameters.customerid;
                return repos.GetAccounts(Guid.Parse(customerId));

                
            });

            Post("/{customerid}", (parameters) => {

                var customerId = (string) parameters.customerid;
                Account account = repos.Save(Guid.Parse(customerId));

                        
                return account.AccountId;
            });

        }


    }
}
