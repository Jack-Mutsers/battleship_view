﻿using Entities.DataModels;
using Entities.Enums;
using Entities.Models;
using Newtonsoft.Json;
using ServiceBus.ServiceBusHandlers;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceBus.ConnectionHandlers
{
    public class QueueWriterHandler
    {
        private IServiceBusQueueHandler _WriterQueueHandler;
        public QueueData QueueData { get; private set; }

        private SynchronizationContext _currentSynchronizationContext; // Needed to Synchronize between threads, Service buss handler is called from another thread

        public QueueWriterHandler(QueueData writerData)
        {
            _currentSynchronizationContext = SynchronizationContext.Current;

            // set the session data
            QueueData = writerData;

            // assign handler
            _WriterQueueHandler = new ServiceBusQueueHandler(writerData.QueueConnectionString, writerData.queueName);

        }

        public async Task SendQueueMessageAsync(string message, MessageType type, QueueData queueData = null)
        {
            // create trasfer model to differentiate between message types
            Transfer transfer = new Transfer();
            transfer.message = message;
            transfer.type = type;
            transfer.QueueData = queueData;

            // convert trasfer model to string for transfere
            string line = JsonConvert.SerializeObject(transfer);

            // sent the message string to the service bus
            await _WriterQueueHandler.SendMessagesAsync(line, QueueData.sessionCode);
        }

        public async Task DisconnectFromQueue()
        {
            await _WriterQueueHandler.DisconnectAsync();
            await Task.CompletedTask;
        }
    }
}
