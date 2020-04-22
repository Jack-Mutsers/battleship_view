using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleship_view.Models;
using Database.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceBus.Entities.models;

namespace battleship_view
{
    public class PlayingFieldModel : PageModel
    {
        public static int shotid { get; private set; }
        public static string Coördinate { get; private set; }
        public string Test { get; private set; }
        string _placeholderShotReponse = "{player} shot at field: {field} row: {row} col: {col}, and has {hit}";


        public void OnGet()
        {
            HandleHitResponse();
        }

        public void OnPostShoot()
        {

            Coördinate = Request.Form["button"];
            Test = Request.Form["Test"];

            MyField myField = GetMyDummyField();
            Coordinates firedCoordinate = new Coordinates();
            firedCoordinate.row = 1;
            firedCoordinate.col = 5;
            //Shot shot = new Shot(firedCoordinate, myField);
            //Hit = shot.CheckForHit();

        }

        public static void GetCoordinates(int Id)
        {
            shotid = Id;
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

        public MyField GetMyDummyField()
        {
            MyField myField = new MyField() {
                fieldNumber = 1,
                boats = new List<Boat>()
                {
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { row = 1, col = 1 }, new Coordinates() { row = 1, col = 2 }, new Coordinates() { row = 1, col = 3 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { row = 5, col = 9 }, new Coordinates() { row = 6, col = 9 }, new Coordinates() { row = 7, col = 9 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { row = 7, col = 7 }, new Coordinates() { row = 7, col = 8 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { row = 3, col = 4 }, new Coordinates() { row = 4, col = 4 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { row = 9, col = 7 }, new Coordinates() { row = 9, col = 8 }, new Coordinates() { row = 9, col = 9 }
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

    }
}