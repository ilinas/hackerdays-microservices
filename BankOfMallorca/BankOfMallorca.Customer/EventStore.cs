using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace BankOfMallorca.Customer
{
    public class EventStore : IEventStore
    {
        private const string StreamName = "customer-events";
        private static readonly IEventStoreConnection Connection = EventStoreConnection.Create(ConnectionSettings.Default, new Uri("tcp://localhost:1113"));
        private static bool IsConnected = false;
        private static readonly ManualResetEvent IsConnecting = new ManualResetEvent(true);

        static EventStore()
        {
            Connection.Connected += (sender, args) =>
            {
                IsConnected = true;
                IsConnecting.Set();
            };
        }

        public async Task Raise(string eventName, object payload)
        {
            var eventData = new EventData(Guid.NewGuid(), eventName, true, Serialize(payload), null);

            await EnsureConnected();
            await Connection.AppendToStreamAsync(StreamName, ExpectedVersion.Any, eventData);
        }

        public async Task<IEnumerable<Event>> GetRange(long start, long end)
        {
            await EnsureConnected();
            var slice = await Connection.ReadStreamEventsForwardAsync(StreamName, start, (int) (end - start + 1), false);

            var events = slice.Events
                .Select(re => re.Event)
                .Select(MapToEvent);

            return events.ToList();
        }

        private static Event MapToEvent(RecordedEvent e)
        {
            var json = Deserialize(e.Data);
            return new Event(e.EventNumber, e.EventType, json)
            {
                Timestamp = e.Created
            };
        }

        private static async Task EnsureConnected()
        {
            if (!IsConnected && IsConnecting.WaitOne())
            {
                if (!IsConnected)
                {
                    IsConnecting.Reset();
                    await Connection.ConnectAsync();
                }
            }
        }

        private static string Deserialize(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        private static byte[] Serialize(object payload)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));
        }
    }
}