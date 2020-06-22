using Entities.DataModels;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using ServiceBus.ServiceBusHandlers;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBus.ConnectionHandlers
{
    public class TopicConnectionHandler
    {
        private IServiceBusTopicHandler _TopicHandler;
        public TopicData TopicData { get; private set; }

        public delegate void DataReceivedEventHandler(string source);
        public event DataReceivedEventHandler MessageReceived;

        public TopicConnectionHandler(TopicData data)
        {
            MessageReceived += DoNothing;

            // set topic data
            TopicData = data;

            // make sure handler is clear before setting a new one
            _TopicHandler = null;

            // convert subscription emum to string
            string subscriptionName = Enum.GetName(typeof(Subscriptions), TopicData.subscription);

            // assign handler
            _TopicHandler = new ServiceBusTopicHandler(TopicData.TopicConnectionString, TopicData.topic, subscriptionName, ProcessTopicMessagesAsync);

        }

        private void DoNothing(string message){ } // this is required for the event, so we can use the event in another class

        public async void SendTopicMessage(string message, MessageType type)
        {
            ServiceBusLog serviceBusLog = new ServiceBusLog()
            {
                playerId = StaticResources.user.PlayerId,
                SendTime = DateTime.Now
            };

            // create trasfer model to differentiate between message types
            Transfer transfer = new Transfer();
            transfer.message = message;
            transfer.type = type;
            transfer.serviceBusLog = serviceBusLog;

            // convert trasfer model to string for transfere
            string line = JsonConvert.SerializeObject(transfer);

            // sent the message string to the service bus
            await _TopicHandler.SendMessagesAsync(line);
        }

        public async Task ProcessTopicMessagesAsync(Message message, CancellationToken token)
        {
            // Process the message.
            string val = $"{Encoding.UTF8.GetString(message.Body)}";

            // check if the message is json encoded
            if (val.StartsWith("{") && val.EndsWith("}") && _TopicHandler != null){

                // close recieved message
                await _TopicHandler.CompleteMessageAsync(message.SystemProperties.LockToken);

                Transfer transfer = JsonConvert.DeserializeObject<Transfer>(val);

                ServiceBusLog log = transfer.serviceBusLog;

                var result = StaticResources.sevicebusLogs.Where(sbl => sbl.playerId == log.playerId && sbl.SendTime == log.SendTime).FirstOrDefault();

                if (result == null)
                {
                    StaticResources.sevicebusLogs.Add(result);
                    
                    // send message to the MessageReceived event
                    MessageReceived(val);
                }
            }
        }

    }
}
