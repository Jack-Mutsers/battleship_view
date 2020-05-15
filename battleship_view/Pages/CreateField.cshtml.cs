using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Logic;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace battleship_view
{
    public class CreateFieldModel : PageModel
    {
        public void OnGet()
        {

        }

        public void OnPostReadyUp([FromBody] List<Boat> boats)
        {
            foreach (Boat boat in boats)
            {
                foreach (Coordinates coordinate in boat.coordinates)
                {
                    coordinate.field = StaticResources.user.orderNumber;
                }
            }

            StaticResources.field = new PlayerField()
            {
                fieldNumber = StaticResources.user.orderNumber,
                boats = boats
            };

            StaticResources.user.ready = true;

            SendReadyUpMessage();
        }

        private void SendReadyUpMessage()
        {
            string line = JsonConvert.SerializeObject(StaticResources.user);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.ReadyUp);
        }

        public void OnTopicMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.ReadyUp)
            {
                Player player = JsonConvert.DeserializeObject<Player>(transfer.message);

                int count = 0;
                for (int i = 0; i < StaticResources.PlayerList.Count(); i++)
                {
                    if (StaticResources.PlayerList[i].PlayerId == player.PlayerId)
                    {
                        StaticResources.PlayerList[i] = player;
                    }

                    if (StaticResources.PlayerList[i].ready == true)
                    {
                        count++;
                    }
                }

                if (count == 4)
                {
                    // go to next screen
                }
            }
        }

    }
}