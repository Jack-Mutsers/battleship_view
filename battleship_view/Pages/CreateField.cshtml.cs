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

        public void OnPost()
        {
            List<Boat> boats = new List<Boat>();
            //foreach () // foreach boat
            //{
            //    List<Coordinates> coordinates = new List<Coordinates>();

            //    foreach () //foreach boat coordiantes
            //    {
            //        Coordinates coordinate = new Coordinates()
            //        {
            //            field = StaticResources.user.orderNumber,
            //            row = ,
            //            col =
            //        };

            //        coordinates.Add(coordinate);
            //    }

            //    Boat boat = new Boat()
            //    {
            //        coordinates = coordinates
            //    };

            //    boats.Add(boat);
            //}

            StaticResources.field = new PlayerField()
            {
                fieldNumber = StaticResources.user.orderNumber,
                boats = boats
            };
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

        public void OnPostUploadField([FromBody] List<List<Coordinates>> JSON)
        {
            StaticResources.user.ready = true;

            SendReadyUpMessage();
        }

    }
}