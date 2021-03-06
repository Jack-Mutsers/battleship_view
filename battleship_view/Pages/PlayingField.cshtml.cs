﻿using System;
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
using GameLogic;
using Contracts;
using ServiceBusEntities.Models;
using Database.Controllers;

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
            TimerHandler.SetTimer();
            TimerHandler.StartTimer();
            if (StaticResources.PlayerList.Count() == 0)
            {
                dummy.SetDummyData();
            }

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
            }
            
            ServiceBusHandler.program.topic.MessageReceived += OnTopicMessageReceived;

            players = StaticResources.PlayerList;

            StaticResources.log.MyTurn = StaticResources.user.orderNumber == 1 ? true : false;
        }

        public void OnTopicMessageReceived(string message)
        {
            var result = StaticResources.sevicebusLogs.Where(sbl => sbl == message).FirstOrDefault();
            if (result == null)
            {
                StaticResources.sevicebusLogs.Add(message);

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

                            sender.SendHitResponseMessage(action.coordinates, hit, gameOver, action.playerId);
                        }

                        // reset timer and increase turn
                        TimerHandler.ResetTime();
                    }

                }

                if (transfer.type == MessageType.Surrender)
                {
                    var settings = new JsonSerializerSettings()
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };
                    SurrenderResponse response = JsonConvert.DeserializeObject<SurrenderResponse>(transfer.message, settings);
                    Player player = StaticResources.PlayerList.Where(Speler => Speler.PlayerId == response.playerId).First();

                    // enter code here to display surrender message in log
                    string logEntry = "{player} has surrendered";
                    logEntry = logEntry.Replace("{player}", player.name);
                    WriteMessageToLog(logEntry);

                    // start gameover function
                    HandleGameOver(response.playerId, response.field);
                    // reset timer and increase turn
                    TimerHandler.ResetTime();
                }

                if (transfer.type == MessageType.GameResponse)
                {
                    GameResponse response = JsonConvert.DeserializeObject<GameResponse>(transfer.message);

                    HandleHitResponse(response);
                }
            }
        }

        private void HandleGameOver(int playerId, IPlayerField field = null)
        {
            var player = StaticResources.PlayerList.FirstOrDefault(Speler => Speler.PlayerId == playerId);

            string logEntry = "All boats of {player} have been destroyed";
            logEntry = logEntry.Replace("{player}", player.name);
            WriteMessageToLog(logEntry);

            player.GameOver = true;

            CheckforHighscoreUpdate(player);

            if (field != null)
            {
                // display all boats in field as sunk
                // store all ship coordinates as GameResponse hit = true

                foreach (var boat in field.boats)
                {
                    foreach (var coordinate in boat.coordinates)
                    {
                        ShotLog shotLog = new ShotLog()
                        {
                            coordinate = coordinate,
                            hit = true
                        };

                        StaticResources.log.shotLog.Add(shotLog);
                    }
                }

            }

            int count = StaticResources.PlayerList.Where(p => p.GameOver == false).Count();

            if (count == 1)
            {
                TimerHandler.ResetHandler();
                player = StaticResources.PlayerList.FirstOrDefault(Speler => Speler.GameOver == false);
                StaticResources.log.winner = player.name;

                string message = player.name + " has won the game";
                WriteMessageToLog(message);
                CheckforHighscoreUpdate(player);
            }
        }

        public void CheckforHighscoreUpdate(Player player)
        {
            if (player.PlayerId == StaticResources.user.PlayerId)
            {
                HighscoreController highscoreController = new HighscoreController();
                highscoreController.StoreNewHighscoreRecord(StaticResources.records);
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

            ShotLog shotLog = new ShotLog()
            {
                coordinate = gameResponse.coordinates,
                hit = gameResponse.hit
            };

            StaticResources.log.shotLog.Add(shotLog);

            Player player = StaticResources.PlayerList.Where(p => p.PlayerId == response.playerId).FirstOrDefault();

            string newstring = _placeholderShotReponse.Replace("{player}", player.name)
                .Replace("{field}", response.coordinates.field.ToString())
                .Replace("{row}", response.coordinates.row.ToString())
                .Replace("{col}", response.coordinates.col.ToString())
                .Replace("{hit}", response.hit ? "landed a hit" : "missed");

            WriteMessageToLog(newstring);

            if (player.PlayerId == StaticResources.user.PlayerId)
            {
                if (response.hit == true) //highscore bijhouden
                {
                    StaticResources.records.hits += 1;
                    StaticResources.records.currenctHitStreak += 1;
                    if (StaticResources.records.currenctHitStreak > StaticResources.records.highestHitStreak)
                    {
                        StaticResources.records.highestHitStreak = StaticResources.records.currenctHitStreak;
                    }
                }
                else
                {
                    StaticResources.records.currenctHitStreak = 0;
                }
            }

            // start gameover function if player is gameover
            if (response.gameOver)
            {
                HandleGameOver(response.senderId);
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

            List<Coordinate> coordinates = new List<Coordinate>();

            foreach (Boat boat in StaticResources.field.boats)
            {
                foreach (Coordinate coordinate in boat.coordinates)
                {
                    coordinates.Add(coordinate);
                }
            }

            return new JsonResult(coordinates);
        }

        public void OnGetSurrender()
        {
            if (StaticResources.user.GameOver == false)
            {
                DateTime date = DateTime.Now;
                if (StaticResources.log.MyTurn && TimerHandler.startOfTurn < date.AddSeconds(-2))
                {
                    StaticResources.user.GameOver = true;
                    sender.SendSurrenderMessage();
                }
            }
        }

        public ActionResult OnPostShoot([FromBody]Coordinate coordinates)
        {
            DateTime date = DateTime.Now;
            if (StaticResources.log.MyTurn && TimerHandler.startOfTurn < date.AddSeconds(-2))
            {
                StaticResources.log.MyTurn = false;
                StaticResources.records.shots += 1; //highscores bijhouden
                sender.SendShootMessage(coordinates);
            }
            return new JsonResult(true);
        }

        public void OnGetFinishGame()
        {
            StaticResources.gameCompleted = true;
        }

        /****************************************************************************************************************************************************
        *                                                              end of Ajax Methods                                                                  *
        /***************************************************************************************************************************************************/
    }
}