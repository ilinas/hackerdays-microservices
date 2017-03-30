using System;

namespace BankOfMallorca.Customer
{
    public class Event
    {
        public Event(int seqNo, string eventName, object payload)
        {
            SeqNo = seqNo;
            EventName = eventName;
            Payload = payload;
            Timestamp = DateTime.Now;
        }

        public int SeqNo { get; set; }

        public DateTime Timestamp { get; set; }
        
        public string EventName { get; }

        public object Payload { get; }
    }
}