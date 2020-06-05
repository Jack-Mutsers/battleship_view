using Entities.DataModels;
using Microsoft.Azure.ServiceBus;
using ServiceBus.ServiceBusHandlers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBus.ConnectionHandlers
{
    public class QueueListnerHandler
    {
        private IServiceBusQueueHandler _ListnerQueueHandler;
        public QueueData QueueData { get; private set; }

        public delegate void DataReceivedEventHandler(string source);
        public event DataReceivedEventHandler MessageReceived;

        public QueueListnerHandler(QueueData listnerData)
        {
            MessageReceived += DoNothing;

            // set the session data
            QueueData = listnerData;

            // assign handler
            _ListnerQueueHandler = new ServiceBusQueueHandler(QueueData.QueueConnectionString, QueueData.queueName, ProcessQueueSessionAsync);
        }

        private void DoNothing(string message){ } // this is required for the event, so we can use the event in another class

        public async Task ProcessQueueSessionAsync(Message message, CancellationToken token)
        {
            // Process the message.
            string val = $"{Encoding.UTF8.GetString(message.Body)}";

            // check if the message is json encoded
            if (val.StartsWith("{") && val.EndsWith("}"))
            {
                // send message to the setResponse method
                MessageReceived(val);
            }

            // complete the message so it is not recieved by anyone else
            await Task.CompletedTask;
        }

        public void DisconnectFromQueue()
        {
            _ListnerQueueHandler.DisconnectAsync();
        }
    }
}
