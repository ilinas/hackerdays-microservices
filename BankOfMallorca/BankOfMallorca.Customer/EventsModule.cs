using Nancy;

namespace BankOfMallorca.Customer
{
    public class EventsModule : NancyModule
    {
        public EventsModule(IEventStore eventStore) : base("/events")
        {
            Get("/", async _ =>
            {
                long start;
                if (!long.TryParse(Request.Query.start.Value, out start))
                {
                    start = 0;
                }

                long end;
                if (!long.TryParse(Request.Query.end.Value, out end))
                {
                    end = start + 4095;
                }

                if (end < start)
                {
                    return HttpStatusCode.BadRequest;
                }

                return await eventStore.GetRange(start, end);
            });
        }
    }
}