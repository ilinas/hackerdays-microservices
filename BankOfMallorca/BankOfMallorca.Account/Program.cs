using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Net.Http;

namespace BankOfMallorca.Account
{
    public class Program

    {
       

        static Timer timer;

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
            PollingService();
            host.Run();
        }

        public static void PollingService()
        {


            AccountEventHandler aeh = new AccountEventHandler(new ServiceEventDescription("localhost", "9250", "/events"));

            timer = new Timer((state) => {

               
                aeh.handleEventsFromCustomerServiceAsync();
                Console.WriteLine("Timer tick");
            }, null, 1000, 1000);
          
            
        }
    }
}
