using System;

namespace BankOfMallorca.Account
{
    internal class Event
    {

        public int SeqNo { get; set; }

        public DateTime Timestamp { get; set; }

        public string EventName { get; set; }

        public string Payload { get; set; }

    }
}