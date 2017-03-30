using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BankOfMallorca.Account
{
    public class AccountEventHandler
    {
        static HttpClient client = new HttpClient();

        private ServiceEventDescription serviceEventDescription;

        public AccountEventHandler(ServiceEventDescription serviceEventDescription)
        {
            this.serviceEventDescription = serviceEventDescription;
            client.BaseAddress = new Uri(serviceEventDescription.GetBase());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



        }
        internal async void handleEventsFromCustomerServiceAsync()
        {
            List<Event> events = await GetEvents();

            foreach (var item in events)
            {
               if (item.EventName == "CustomerCreated")
                {
                    var e = JsonConvert.DeserializeObject<CustomerCreatedEvent>(item.Payload);

                    InMemoryAccountRepository m = new InMemoryAccountRepository();
                    m.Save(Guid.Parse(e.Id));
                    
                }

                Console.WriteLine("EventName : " + item.EventName);
            }

        }

        async Task<List<Event>> GetEvents()
        {
            HttpResponseMessage response = await client.GetAsync(serviceEventDescription.GetPath());
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine("JSON:" + json);
                return JsonConvert.DeserializeObject<List<Event>>(json);
            }
            return null;
        }
    }
}
