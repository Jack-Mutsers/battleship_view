using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Logic;
using Database.Controllers;
using Entities.Enums;
using Entities.Models;
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
        private bool start { 
            get { return StaticResources.startLobby; }
            set { StaticResources.startLobby = value; }
        }

        public void OnGet()
        {

        }

        public async void OnGetJoinHost(string name, string sessionCode)
        {
            // check if handler is empty, if so create an instance of it
            if (ServiceBusHandler.program == null)
            {
                PlayerController playerController = new PlayerController();
                
                Player player = new Player();
                player.PlayerId = playerController.CreateNewPlayer(name);
                player.name = name;
                player.type = PlayerType.Guest;

                StaticResources.sessionCode = sessionCode;

                // create an instance of the servicebus handler
                await ServiceBusHandler.InitiateServiceBusHandler(player);
                await ServiceBusHandler.program.CreateQueueListner(PlayerType.Guest);
                await ServiceBusHandler.program.CreateQueueWriter(PlayerType.Guest);

                ServiceBusHandler.program.QueueListner.MessageReceived += OnQueueMessageReceived;

                string message = JsonConvert.SerializeObject(StaticResources.user);

                await ServiceBusHandler.program.QueueWriter.SendQueueMessageAsync(message, MessageType.JoinRequest, ServiceBusHandler.program.QueueListner.QueueData);
                await ServiceBusHandler.program.QueueWriter.DisconnectFromQueue();
                ServiceBusHandler.program.QueueListner.ConnectToQueue();
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

            if (transfer.type == MessageType.StartGame)
            {
                start = true;
            }
        }

        public ActionResult OnGetChangeChecker()
        {
            return new JsonResult(StaticResources.PlayerList);
        }

        public ActionResult OnGetStartCheck()
        {
            return new JsonResult(start);
        }

        public void OnGetRequestNewPlayerList()
        {
            ServiceBusHandler.SendPlayerListRequest(); 
        }
    }
}