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
        MessageSender sender = new MessageSender();
        Dummy dummy = new Dummy();
        string _placeholderShotReponse = "{player} shot at field: {field} row: {row} col: {col}, and has {hit}";

        public Player playerId { get; private set; } = StaticResources.user;

        public List<Player> players { get; set; } = StaticResources.PlayerList.Count == 0 ? StaticResources.dummyPlayers : StaticResources.PlayerList;



        public async void OnGet()
        {
            dummy.SetDummyData();

            StaticResources.field.fieldNumber = StaticResources.user.orderNumber;

            if (ServiceBusHandler.program == null)
            {
                Player player = dummy.GetDummyPlayer();

                //field-id doorgeven
                playerId = player;

                // initialise SessionCodeGenerator
                SessionCodeGenerator generator = new SessionCodeGenerator();

                // Generade sessionCode
                StaticResources.sessionCode = generator.GenerateSessionCode();

                await ServiceBusHandler.InitiateServiceBusHandler(player, true);
                ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;
            }

            players = StaticResources.PlayerList;
        }

        public void OnTopicMessageReceived(string message)
        {
            Transfer transfer = JsonConvert.DeserializeObject<Transfer>(message);

            if (transfer.type == MessageType.Action)
            {
                GameAction action = JsonConvert.DeserializeObject<GameAction>(transfer.message);
                Player player = StaticResources.PlayerList.Where(Speler => Speler.PlayerId == action.playerId).First();

                if (action.action == PlayerAction.shoot)
                {
                    if (action.coordinates.field == StaticResources.user.orderNumber)
                    {
                        // shot is directed at my field

                        bool hit = StaticResources.field.CheckForHit(action.coordinates);
                        bool gameOver = StaticResources.field.CheckForGameOver();

                        sender.SendHitResponseMessage(action.coordinates, hit, gameOver);
                    }
                }

            }

            if (transfer.type == MessageType.Surrender)
            {
                SurrenderResponse response = JsonConvert.DeserializeObject<SurrenderResponse>(transfer.message);
                Player player = StaticResources.PlayerList.Where(Speler => Speler.PlayerId == response.playerId).First();

                // enter code here to display surrender message in log
                string logEntry = "{player} has surrendered";
                logEntry = logEntry.Replace("{player}", player.name);
                WriteMessageToLog(logEntry);

                // start gameover function
                HandleGameOver(response.playerId, response.field);
            }

            if (transfer.type == MessageType.GameResponse)
            {
                GameResponse response = JsonConvert.DeserializeObject<GameResponse>(transfer.message);

                HandleHitResponse(response);
            }
        }

        private void HandleGameOver(int playerId, PlayerField field = null)
        {
            Player player = StaticResources.PlayerList.Where(Speler => Speler.PlayerId == playerId).First();

            string logEntry = "All boats of {player} have been destroyed";
            logEntry = logEntry.Replace("{player}", player.name);
            WriteMessageToLog(logEntry);

            if (field != null)
            {
                // display all boats in field as sunk
                // store all ship coordinates as GameResponse hit = true

                foreach (var boat in field.boats)
                {
                    foreach (var coordinate in boat.coordinates)
                    {
                        GameResponse response = new GameResponse()
                        {
                            fieldNumber = coordinate.field,
                            coordinates = coordinate,
                            gameOver = true,
                            hit = true,
                        };

                        StaticResources.log.shotLog.Add(response);
                    }
                }

            }
        }

        public void WriteMessageToLog(string logEntry)
        {
            // implement function to write the message to the log
            StaticResources.log.gameLog.Add(logEntry);
        }

        public void HandleHitResponse(GameResponse gameResponse = null)
        {
            if (gameResponse == null)
            {
                return;
            }

            GameResponse response = gameResponse == null ? dummy.GetHitResponseDummyData() : gameResponse;
            StaticResources.log.shotLog.Add(response);

            Player player = StaticResources.PlayerList.Where(p => p.PlayerId == response.playerId).FirstOrDefault();

            string newstring = _placeholderShotReponse.Replace("{player}", player.name)
                .Replace("{field}", response.coordinates.field.ToString())
                .Replace("{row}", response.coordinates.row.ToString())
                .Replace("{col}", response.coordinates.col.ToString())
                .Replace("{hit}", response.hit ? "landed a hit" : "missed");

            WriteMessageToLog(newstring);

            // start gameover function if player is gameover
            if (response.gameOver)
            {
                HandleGameOver(response.playerId);
            }
        }


        /****************************************************************************************************************************************************
        *                                                             Start of Ajax Methods                                                                 *
        /***************************************************************************************************************************************************/

        public ActionResult OnGetChangeChecker()
        {
            //HandleHitResponse();

            return new JsonResult(StaticResources.log);
        }

        public ActionResult OnGetPlayerData()
        {
            return new JsonResult(StaticResources.user);
        }

        public ActionResult OnGetBoatCoordinates()
        {
            StaticResources.field = StaticResources.field.boats == null ? dummy.GetMyDummyField() : StaticResources.field;

            List<Coordinates> coordinates = new List<Coordinates>();

            foreach (Boat boat in StaticResources.field.boats)
            {
                foreach (Coordinates coordinate in boat.coordinates)
                {
                    coordinates.Add(coordinate);
                }
            }

            return new JsonResult(coordinates);
        }

        public void OnGetSurrender()
        {
            sender.SendSurrenderMessage();
        }

        //public ActionResult OnGetFieldDisable()
        //{
        //    int playerCount = new int();
        //    playerCount = players.Count;

        //    return new JsonResult(playerCount);
        //}

        public ActionResult OnPostShoot([FromBody]Coordinates coordinates)
        {           
            sender.SendShootMessage(coordinates);

            return new JsonResult(true);
        }

        /****************************************************************************************************************************************************
        *                                                              end of Ajax Methods                                                                  *
        /***************************************************************************************************************************************************/
    }
}