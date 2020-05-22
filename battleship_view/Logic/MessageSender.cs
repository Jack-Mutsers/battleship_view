using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_view.Logic
{
    public class MessageSender
    {
        public void SendHitResponseMessage(Coordinates shot, bool hit, bool gameOver)
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
            SurrenderResponse response = new SurrenderResponse()
            {
                playerId = StaticResources.user.PlayerId,
                field = StaticResources.field
            };

            string line = JsonConvert.SerializeObject(response);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.Surrender);
        }

        public void SendShootMessage(Coordinates coordinates)
        {
            GameAction action = new GameAction()
            {
                action = PlayerAction.shoot,
                coordinates = new Coordinates()
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
