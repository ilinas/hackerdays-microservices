using System.Collections.Generic;
using System.Linq;

namespace BankOfMallorca.Customer
{
    public class InMemoryEventStore : IEventStore
    {
        private static readonly IList<Event> Events = new List<Event>();

        public void Raise(string eventName, object payload)
        {
            var seqNo = Events.Count;
            Events.Add(new Event(seqNo, eventName, payload));
        }

        public IEnumerable<Event> GetRange(int start, int end)
        {
            return Events.Skip(start).Take(end - start + 1);
        }
    }
}