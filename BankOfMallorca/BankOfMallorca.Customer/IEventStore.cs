using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankOfMallorca.Customer
{
    public interface IEventStore
    {
        Task Raise(string eventName, object payload);
        Task<IEnumerable<Event>> GetRange(long start, long end);
    }
}