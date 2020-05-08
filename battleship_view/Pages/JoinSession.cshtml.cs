using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Logic;
using Entities.Enums;
using Entities.models;
using Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace battleship_view
{
    public class JoinSessionModel : PageModel
    {
        public string sessionCode { get; set; } = "";
        public List<Player> players { get; set; } = StaticResources.PlayerList;

        public void OnGet()
        {

        }


        public async void OnGetJoinHost(string name, string sessionCode)
        {
            // check if handler is empty, if so create an instance of it
            if (ServiceBusHandler.program == null)
            {
                Player player = new Player();
                player.name = name;
                player.type = PlayerType.Guest;

                StaticResources.sessionCode = sessionCode;

                // create an instance of the servicebus handler
                bool initialised = await ServiceBusHandler.InitiateServiceBusHandler(player);
                bool listnerCreated = await ServiceBusHandler.program.CreateQueueListner(PlayerType.Guest);
                bool writerCreated = await ServiceBusHandler.program.CreateQueueWriter(PlayerType.Guest);

                ServiceBusHandler.program.QueueListner.MessageReceived += OnQueueMessageReceived;
            }

            sessionCode = StaticResources.sessionCode;
            players = StaticResources.PlayerList;

        }

        public void OnQueueMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.Response)
            {
                ServiceBusHandler.HandleQueueMessage(message);
                sessionCode = StaticResources.sessionCode;
                ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;
            }
        }

        public void OnTopicMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.NewPlayer)
            {
                ServiceBusHandler.HandleNewPlayerTopicMessage(message);
                players = StaticResources.PlayerList;
            }
        }

    }
}