using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfMallorca.Customer
{
    public class InMemoryEventStore : IEventStore
    {
        private static readonly IList<Event> Events = new List<Event>();

        public Task Raise(string eventName, object payload)
        {
            Events.Add(new Event(Events.Count, eventName, payload));
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Event>> GetRange(long start, long end)
        {
            var events = Events.Skip((int)start).Take((int)(end - start) + 1);
            return Task.FromResult(events);
        }
    }
}