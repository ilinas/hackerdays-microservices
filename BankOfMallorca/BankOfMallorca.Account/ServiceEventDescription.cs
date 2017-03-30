using System;

namespace BankOfMallorca.Account
{
    public class ServiceEventDescription

    {

      public ServiceEventDescription(string hostName,string port, string eventFeedPath)
        {
            HostName = hostName;
            Port = port;
            EventFeedPath = eventFeedPath;
        }

        public string HostName { get; private set; }
        public string Port { get; private set; }
        public string EventFeedPath { get; private set; }

        internal string GetPath()
        {
            return EventFeedPath;
        }

        internal string GetBase()
        {
            return "http://" + HostName + ":" + Port;
        }
    }
}