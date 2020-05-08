using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using Entities.models;
using Entities.Resources;
using battleship_view.Logic;
using Newtonsoft.Json;
using Entities.Enums;

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
                string sessionCode = generator.GenerateSessionCode();

                StaticResources.sessionCode = sessionCode;

                // Set player data
                Player player = new Player();
                player.name = name;
                player.type = PlayerType.Host;
                player.orderNumber = 1;

                // create an instance of the servicebus handler
                bool initialised = await ServiceBusHandler.InitiateServiceBusHandler(player, true);
                bool created = await ServiceBusHandler.program.CreateQueueListner(PlayerType.Host);

                ServiceBusHandler.program.QueueListner.MessageReceived += OnQueueMessageReceived;
                ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;

            }

            sessionCode = StaticResources.sessionCode;
            players = StaticResources.PlayerList;

        }

        public void OnQueueMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.JoinRequest)
            {
                ServiceBusHandler.HandleQueueMessage(message);
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
        }

        public ActionResult OnGetSessionCode()
        {
            return null; //new JsonResult(SessionCode());
        }

        //public string SessionCode()
        //{
        //    int length = 5;

        //    // creating a StringBuilder object()
        //    StringBuilder str_build = new StringBuilder();
        //    Random random = new Random();

        //    char letter;

        //    for (int i = 0; i < length; i++)
        //    {
        //        int val= random.Next(0,2);
        //        if(val == 0)
        //        {
        //            double flt = random.NextDouble();
        //            int shift = Convert.ToInt32(Math.Floor(25 * flt));
        //            letter = Convert.ToChar(shift + 65);
        //            str_build.Append(letter);
        //        }
        //        else
        //        {
        //            int newInt = random.Next(0,10);
        //            str_build.Append(newInt.ToString());
        //        }
                
        //    }

        //    return str_build.ToString();
        //}

    }
}