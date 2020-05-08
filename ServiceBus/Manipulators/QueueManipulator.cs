using Entities.DataModels;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.ServiceBus.Management;
//using Microsoft.ServiceBus;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Manipulators
{
    public static class QueueManipulator
    {

        public async static Task<QueueData> validateExistance(string queueName)
        {
            // Create the topic if it does not exist already.
            string connectionString = ServiceBusData.ConnectionString;


            var test = await CreateNewQueue(connectionString, queueName);

            //while (true)
            //{

            //}
            return test;
        }

        private static async Task<QueueData> CreateNewQueue(string connectionString, string queueName)
        {

            // Configure Topic Settings.
            QueueDescription qd = new QueueDescription(queueName);
            qd.MaxSizeInMB = 5120;
            qd.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            var managementClient = new ManagementClient(connectionString);

            if ((await managementClient.QueueExistsAsync(queueName)) == false)
            {
                await managementClient.CreateQueueAsync(queueName);
            }

            QueueData data = new QueueData()
            {
                QueueConnectionString = connectionString,
                queueName = queueName
            };

            return data;
        }

        public static async void DeleteQueue(string queueName)
        {
            string connectionString = ServiceBusData.ConnectionString;
            var managementClient = new ManagementClient(connectionString);
            await managementClient.DeleteQueueAsync(queueName);
        }
    }
}
