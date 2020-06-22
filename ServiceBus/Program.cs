using Entities.DataModels;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using ServiceBus.ConnectionHandlers;
using ServiceBus.Manipulators;
using System.Threading.Tasks;

namespace ServiceBus
{
    public class Program
    {
        public QueueListnerHandler QueueListner { get; private set; }
        public QueueWriterHandler QueueWriter { get; private set; }
        public TopicConnectionHandler topic { get; private set; }

        public Program(Player player)
        {
            StaticResources.user = player;
        }

        public async Task CreateQueueListner(PlayerType playerType)
        {
            QueueTypes queueTypes = new QueueTypes();

            string queueName = playerType == PlayerType.Host ?
                "Join-" + StaticResources.sessionCode :
                "response-" + StaticResources.sessionCode + StaticResources.user.PlayerId.ToString();

            QueueData listnerData = await QueueManipulator.validateExistance(queueName);

            // pass over connection data
            QueueListner = new QueueListnerHandler(listnerData);
        }

        public async Task CreateQueueWriter(PlayerType playerType, QueueData queueData = null)
        {
            if (QueueWriter != null)
            {
                await QueueWriter.DisconnectFromQueue();
            }

            QueueTypes queueTypes = new QueueTypes();

            QueueData writerData = queueData;

            if (playerType == PlayerType.Guest)
            {
                string queueName = "Join-" + StaticResources.sessionCode;
                writerData = new QueueData();
                writerData.queueName = queueName;
                writerData.QueueConnectionString = ServiceBusData.ConnectionString;
            }

            // pass over connection data
            QueueWriter = new QueueWriterHandler(writerData);
        }

        public void CreateTopicConnection(TopicData data)
        {
            if (topic == null)
            {
                topic = new TopicConnectionHandler(data);
            }
        }

        public async Task<bool> CreateNewTopic()
        {
            TopicData data = await TopicManipulator.validateExistance();

            CreateTopicConnection(data);

            return true;
        }

        public void DeleteListnerQueue()
        {
            string queueName = QueueListner.QueueData.queueName;

            QueueManipulator.DeleteQueue(queueName);
        }

        public async Task DeleteTopic()
        {
            string topicName = topic.TopicData.topic;

            await TopicManipulator.DeleteTopic(topicName);
        }
    }
}
