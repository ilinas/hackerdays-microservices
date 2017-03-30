using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BankOfMallorca.Customer
{
    public class InMemoryEventStore : IEventStore
    {
        private static readonly IList<Event> Events = new List<Event>();

        public Task Raise(string eventName, object payload)
        {
            var serialized = JsonConvert.SerializeObject(payload);
            Events.Add(new Event(Events.Count, eventName, serialized));
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Event>> GetRange(long start, long end)
        {
            var events = Events.Skip((int)start).Take((int)(end - start) + 1);
            return Task.FromResult(events);
        }
    }
}