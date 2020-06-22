using Entities.DataModels;
using Entities.Enums;
using Entities.Resources;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.ServiceBus.Management;
using System;
using System.Threading.Tasks;

namespace ServiceBus.Manipulators
{
    public static class TopicManipulator
    {
        private static TopicData data { get; set; }

        public async static Task<TopicData> validateExistance()
        {
            // Create the topic if it does not exist already.
            string connectionString = ServiceBusData.ConnectionString;

            // Configure Topic Settings.
            string topicName = "chat-" + StaticResources.sessionCode;

            data = await CreateNewTopic(connectionString, topicName);

            return data;
        }

        private static async Task<TopicData> CreateNewTopic(string connectionString, string topicName)
        {
            var managementClient = new ManagementClient(connectionString);

            TopicDescription td = new TopicDescription(topicName);
            td.MaxSizeInMB = 5120;
            td.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            if ((await managementClient.TopicExistsAsync(topicName)) == false)
            {
                await managementClient.CreateTopicAsync(topicName);
                
                foreach (Subscriptions subscription in (Subscriptions[])Enum.GetValues(typeof(Subscriptions)))
                {
                    // convert subscription emum to string
                    string subscriptionName = Enum.GetName(typeof(Subscriptions), subscription);
                    await CreateSubscription(managementClient, topicName, subscriptionName);
                }
            }

            data = new TopicData()
            {
                TopicConnectionString = connectionString,
                topic = topicName
            };

            return data;
        }

        private static async Task<bool> CreateSubscription(ManagementClient managementClient, string topicName, string subscriptionName)
        {
            string connectionString = ServiceBusData.ConnectionString;

            if (( await managementClient.SubscriptionExistsAsync(topicName, subscriptionName)) == false)
            {
                await managementClient.CreateSubscriptionAsync(topicName, subscriptionName);
            }

            return true;
        }

        public static async Task DeleteTopic(string topicName)
        {
            string connectionString = ServiceBusData.ConnectionString;
            var managementClient = new ManagementClient(connectionString);
            await managementClient.DeleteTopicAsync(topicName);
        }
    }
}
