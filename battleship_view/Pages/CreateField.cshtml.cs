using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Logic;
using battleship_view.Models;
using Contracts;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using GameLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace battleship_view
{
    public class CreateFieldModel : PageModel
    {
        private bool start = false;

        public void OnGet()
        {

        }

        public void OnPost()
        {
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

                if (count == StaticResources.PlayerList.Count())
                {
                    start = true;
                }
            }
        }

        public void OnPostUploadField([FromBody] List<List<Coordinate>> JSON)
        {
            validateUser();
            PlayerField myField = new PlayerField();
            myField.fieldNumber = StaticResources.user.orderNumber;

            foreach (List<Coordinate> coordinatesList in JSON)
            {
                List<ICoordinate> coordinates = coordinatesList.Cast<ICoordinate>().ToList();

                IBoat boat = new Boat();
                boat.FillWithCoordinates(coordinates);

                myField.AddNewBoatToField(boat);
            }

            StaticResources.field = myField;

            StaticResources.user.ready = true;

            SendReadyUpMessage();
        }

        public IActionResult OnGetStartCheck()
        {
            return new JsonResult(start);
        }

        public void validateUser()
        {
            Dummy dummy = new Dummy();
            StaticResources.user = StaticResources.user == null ? dummy.GetDummyPlayer() : StaticResources.user;
        }
    }
}