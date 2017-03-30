using System.Collections.Generic;

namespace BankOfMallorca.Customer
{
    public interface IEventStore
    {
        void Raise(string eventName, object payload);
        IEnumerable<Event> GetRange(int start, int end);
    }
}