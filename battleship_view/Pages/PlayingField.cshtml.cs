using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Models;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Entities.Models;
using battleship_view.Logic;
using Entities.Resources;

namespace battleship_view
{


    public class PlayingFieldModel : PageModel
    {
        string _placeholderShotReponse = "{player} shot at field: {field} row: {row} col: {col}, and has {hit}";

        public List<Player> players { get; set; } = StaticResources.PlayerList;

        public async void OnGet()
        {
            ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;

            StaticResources.field.fieldNumber = GetDummyPlayer().orderNumber;

            SetDummyData();

            if (ServiceBusHandler.program == null)
            {
                await ServiceBusHandler.InitiateServiceBusHandler(StaticResources.user, true);
                ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;
            }
        }
        
        public void OnTopicMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.Action)
            {
                GameAction action = JsonConvert.DeserializeObject<GameAction>(transfer.message);
                Player player = StaticResources.PlayerList.Where(player => player.userId == action.playerId).First();

                if (action.action == PlayerAction.shoot)
                {
                    // enter code here to display action message in log
                    string logEntry = "{player} shot at field: {field} row: {row} col: {col}, and has {hit/missed}";
                    WriteMessageToLog(logEntry);

                    if (action.coordinates.field == StaticResources.user.orderNumber)
                    {
                        // shot is directed at my field

                        bool hit = true; // implement function to check if the shot hit anything

                        bool gameOver = false; // implement function to check if you still have ships alive

                        SendHitResponseMessage(action.coordinates, hit, gameOver);
                    }
                }

            }

            if (transfer.type == MessageType.Surender)
            {
                SurrenderResponse response = JsonConvert.DeserializeObject<SurrenderResponse>(transfer.message);
                Player player = StaticResources.PlayerList.Where(player => player.userId == response.playerId).First();

                // enter code here to display surrender message in log
                string logEntry = "{player} had surrendered";
                WriteMessageToLog(logEntry);

                // start gameover function
                HandleGameOver(response.playerId, response.field);
            }

            if (transfer.type == MessageType.GameResponse)
            {
                GameResponse response = JsonConvert.DeserializeObject<GameResponse>(transfer.message);
                //Player player = StaticResources.PlayerList.Where(player => player.userId == response.playerId).First();

                // write the game response to the log + modify playing field to show what happenend
                string logEntry = response.hit ? 
                    "The shot at {field}, {row}, {col} has landed a hit":
                    "The shot at {field}, {row}, {col} has missed its target";
                WriteMessageToLog(logEntry);


                // start gameover function if player is gameover
                if (response.gameOver)
                {
                    HandleGameOver(response.playerId);
                }
            }
        }

        private void HandleGameOver(Guid playerId, PlayerField field = null)
        {
            Player player = StaticResources.PlayerList.Where(player => player.userId == playerId).First();
            // player.orderNumber == fieldnumber

            // enter code here to display the gameover message in the log
            string logEntry = "All boats of {player} have been destroyed";
            WriteMessageToLog(logEntry);

            if (field != null)
            {
                // display all boats in field as sunk
            }

            // change player field color to indicate the game over
        }

        public void WriteMessageToLog(string logEntry)
        {
            // implement function to write the message to the log
        }

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
                playerId = StaticResources.user.userId
            };

            string line = JsonConvert.SerializeObject(response);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.GameResponse);
        }

        public void SendSurrenderMessage()
        {
            SurrenderResponse response = new SurrenderResponse()
            {
                playerId = StaticResources.user.userId,
                field = StaticResources.field
            };

            string line = JsonConvert.SerializeObject(response);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.GameResponse);
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
                playerId = StaticResources.user.userId,
            };

            string line = JsonConvert.SerializeObject(action);

            ServiceBusHandler.program.topic.SendTopicMessage(line, MessageType.Action);
        }

        public ActionResult OnGetPlayerList()
        {
            return new JsonResult(StaticResources.PlayerList);
        }

        public ActionResult OnGetPlayerData()
        {
            return new JsonResult(StaticResources.user);
        }

        public ActionResult OnGetBoatCoordinates()
        {
            List<Coordinates> coordinates = new List<Coordinates>();

            foreach(Boat boat in StaticResources.field.boats)
            {
                foreach(Coordinates coordinate in boat.coordinates)
                {
                    coordinates.Add(coordinate);
                }
            }

            return new JsonResult(coordinates);
        }

        public void OnGetSerender()
        {
            SendSurrenderMessage();
        }

        public void OnPostShoot([FromBody] Coordinates coordinates)
        {
            SendShootMessage(coordinates);
        }

        public void HandleHitResponse()
        {
            GameResponse response = GetHitResponseDummyData();
            List<Player> players = GetDummyPlayerList();
            
            Player player = players.Where(p => p.userId == response.playerId).FirstOrDefault();

            string newstring = _placeholderShotReponse.Replace("{player}", player.name)
                .Replace("{field}", response.coordinates.field.ToString())
                .Replace("{row}", response.coordinates.row.ToString())
                .Replace("{col}", response.coordinates.col.ToString())
                .Replace("{hit}", "landed an hit");
        }



        /****************************************************************************************************************************************************
        *                                                               Start of dummy data                                                                 *
        /***************************************************************************************************************************************************/

        private async void SetDummyData()
        {
            StaticResources.field = StaticResources.field.boats == null ? GetMyDummyField() : StaticResources.field;
            StaticResources.user = StaticResources.user == null ? GetDummyPlayer() : StaticResources.user;
            StaticResources.PlayerList = StaticResources.PlayerList == null ? GetDummyPlayerList() : StaticResources.PlayerList;

            

        }

        //used to check if your field is under attack + to deremain who did what for the log
        public GameAction GetActionMessageDummyData()
        {
            string message = "{\"playerId\":\"00000000-0000-0000-0000-000000000000\",\"sessionCode\":\"ab6ER8\",\"coordinates\":{\"row\":2,\"col\":2},\"action\":0}";

            return JsonConvert.DeserializeObject<GameAction>(message);
        }

        // used to mark a hit in the field + log message
        public GameResponse GetHitResponseDummyData()
        {
            List<Player> players = GetDummyPlayerList();
            GameResponse response = new GameResponse()
            {
                playerId = players[1].userId,
                fieldNumber = 2,
                coordinates = new Coordinates() { field = 2, col = 2, row = 4 },
                hit = true
            };

            return response;
        }
                
        public List<Player> GetDummyPlayerList()
        {
            List<Player> players = new List<Player>(){
                new Player() { userId = Guid.Parse("{9e0a721a-1725-40b2-bbf7-8f85ed55f6ca}"), name = "Zoë", ready = true, orderNumber = 1, type = PlayerType.Host },
                new Player() { userId = Guid.Parse("{cebfcc68-19ad-42ac-8a01-bddeae6520ce}"), name = "Lean", ready = true, orderNumber = 2, type = PlayerType.Guest },
                new Player() { userId = Guid.Parse("{08bf7d61-21b0-4277-8f47-41dc5e0e009a}"), name = "Martin", ready = true, orderNumber = 3, type = PlayerType.Guest },
                new Player() { userId = Guid.Parse("{89aa512a-e854-4bf1-89cf-d6b59bf30d18}"), name = "Maikel", ready = true, orderNumber = 4, type = PlayerType.Guest }
            };

            return players;
        }

        public PlayerField GetMyDummyField()
        {
            PlayerField myField = new PlayerField() {
                fieldNumber = 1,
                boats = new List<Boat>()
                {
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 1, col = 1 }, new Coordinates() { field = 1, row = 1, col = 2 }, new Coordinates() { field = 1, row = 1, col = 3 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 4, col = 9 }, new Coordinates() { field = 1, row = 5, col = 9 }, new Coordinates() { field = 1, row = 6, col = 9 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 7, col = 7 }, new Coordinates() { field = 1, row = 7, col = 8 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 3, col = 4 }, new Coordinates() { field = 1, row = 4, col = 4 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 9, col = 7 }, new Coordinates() { field = 1, row = 9, col = 8 }, new Coordinates() { field = 1, row = 9, col = 9 }
                        }
                    },
                }
            };

            return myField;
        }

        public Player GetDummyPlayer()
        {
            Player player = new Player() { userId = Guid.Parse("{9e0a721a-1725-40b2-bbf7-8f85ed55f6ca}"), name = "Zoë", ready = true, orderNumber = 1, type = PlayerType.Host };

            return player;
        }

        /****************************************************************************************************************************************************
        *                                                               end of dummy data                                                                 *
        /***************************************************************************************************************************************************/
    }
}