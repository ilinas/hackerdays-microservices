using System;

namespace BankOfMallorca.Customer
{
    public class Event
    {
        public Event(long seqNo, string eventName, object payload)
        {
            SeqNo = seqNo;
            EventName = eventName;
            Payload = payload;
        }

        public long SeqNo { get; set; }

        public DateTime Timestamp { get; set; }
        
        public string EventName { get; }

        public object Payload { get; }
    }
}