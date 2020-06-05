using Contracts;
using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using GameLogic;
using Newtonsoft.Json;
using ServiceBusEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_view.Logic
{
    public class MessageSender
    {
        public void SendHitResponseMessage(Coordinate shot, bool hit, bool gameOver)
        {
            // col = 0 - 9
            // row = 0 - 9

            GameResponse response = new GameResponse()
            {
                fieldNumber = StaticResources.user.orderNumber,
                coordinates = shot,
                hit = hit,
                gameOver = gameOver,
                playerId = StaticResources.user.PlayerId
            };

            string line = JsonConvert.SerializeObject(response);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.GameResponse);
        }

        public void SendSurrenderMessage()
        {
            PlayerField field = new PlayerField()
            {
                fieldNumber = StaticResources.field.fieldNumber,
                hitList = StaticResources.field.hitList
            };

            foreach (IBoat boat in StaticResources.field.boats)
                field.AddNewBoatToField(boat);

            SurrenderResponse response = new SurrenderResponse()
            {
                playerId = StaticResources.user.PlayerId,
                field = field
            };

            string line = JsonConvert.SerializeObject(response);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.Surrender);
        }

        public void SendShootMessage(ICoordinate coordinates)
        {
            GameAction action = new GameAction()
            {
                action = PlayerAction.shoot,
                coordinates = new Coordinate()
                {
                    field = coordinates.field,
                    row = coordinates.row,
                    col = coordinates.col
                },
                playerId = StaticResources.user.PlayerId,
            };

            string line = JsonConvert.SerializeObject(action);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.Action);
        }

    }
}
