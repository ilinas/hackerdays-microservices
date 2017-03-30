using System.Collections.Generic;
using Nancy;

namespace BankOfMallorca.Customer
{
    public class EventsModule : NancyModule
    {
        private readonly IEventStore _eventStore;

        public EventsModule(IEventStore eventStore) : base("/events")
        {
            _eventStore = eventStore;

            Get("/", _ =>
            {
                int start;
                if (!int.TryParse(Request.Query.start.Value, out start))
                {
                    start = 0;
                }

                int end;
                if (!int.TryParse(Request.Query.end.Value, out end))
                {
                    end = int.MaxValue;
                }

                return GetEvents(start, end);
            });
        }

        private IEnumerable<Event> GetEvents(int start, int end)
        {
            return _eventStore.GetRange(start, end);
        }
    }
}