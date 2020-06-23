using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Entities.Models;
using Entities.Resources;
using battleship_view.Logic;
using Newtonsoft.Json;
using Entities.Enums;
using Database.Controllers;

namespace battleship_view
{
    public class CreateSessionModel : PageModel
    {
        public string sessionCode { get; set; } = "";
        public List<Player> players { get; set; } = StaticResources.PlayerList;

        public void OnGet()
        {

        }

        public async void OnPostStartHost(string name)
        {
            // check if handler is empty, if so create an instance of it
            if (ServiceBusHandler.program == null)
            {
                // initialise SessionCodeGenerator
                SessionCodeGenerator generator = new SessionCodeGenerator();

                // Generade sessionCode
                StaticResources.sessionCode = generator.GenerateSessionCode();

                PlayerController playerController = new PlayerController();

                // Set player data
                Player player = new Player();
                player.PlayerId = playerController.CreateNewPlayer(name);
                player.name = name;
                player.type = PlayerType.Host;
                player.orderNumber = 1;

                // create an instance of the servicebus handler
                await ServiceBusHandler.InitiateServiceBusHandler(player, true);
                await ServiceBusHandler.program.CreateQueueListner(PlayerType.Host);
                ServiceBusHandler.program.QueueListner.ConnectToQueue();

                ServiceBusHandler.program.QueueListner.MessageReceived += OnQueueMessageReceived;
                ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;

            }

            sessionCode = StaticResources.sessionCode;
            players = StaticResources.PlayerList;

        }

        public void OnQueueMessageReceived(string message)
        {
            Transfer transferObject = JsonConvert.DeserializeObject<Transfer>(message);

            int count = StaticResources.sevicebusQueueLogs.Where(sql => sql == message).Count();

            bool accept = true;
            if (transferObject.type == MessageType.JoinRequest && count > 0)
                accept = false;

            if (accept)
            {
                if (transferObject.type == MessageType.JoinRequest)
                {
                    StaticResources.sevicebusQueueLogs.Add(message);
                    ServiceBusHandler.HandleQueueMessage(message);
                }
            }
        }

        public void OnTopicMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.NewPlayer)
            {
                ServiceBusHandler.HandleNewPlayerTopicMessage(message);
                sessionCode = StaticResources.sessionCode;
                players = StaticResources.PlayerList;
            }
            else if (transfer.type == MessageType.PlayerListRequest)
            {
                MessageSender messageSender = new MessageSender();
                messageSender.SendNewPlayerMessage();
            }
            else if (transfer.type == MessageType.LeaveLobby)
            {
                Player player = JsonConvert.DeserializeObject<Player>(transfer.message);
                int index = StaticResources.PlayerList.FindIndex(p => p.PlayerId == player.PlayerId);
                StaticResources.PlayerList.RemoveAt(index);

                MessageSender messageSender = new MessageSender();
                messageSender.SendNewPlayerMessage();
            }
        }

        public ActionResult OnGetChangeChecker()
        {
            return new JsonResult(StaticResources.PlayerList);
        }

        public ActionResult OnGetSessionCode()
        {
            return new JsonResult(StaticResources.sessionCode);
        }

        public void OnGetStartGame()
        {
            MessageSender sender = new MessageSender();
            sender.StartGameMessage();
        }
    }
}