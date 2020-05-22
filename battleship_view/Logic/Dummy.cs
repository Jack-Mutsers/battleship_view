﻿using Entities.Enums;
using Entities.Models;
using Entities.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_view.Logic
{
    public class Dummy
    {
        
        public void SetDummyData()
        {
            StaticResources.field = StaticResources.field == null ? GetMyDummyField() : StaticResources.field;
            StaticResources.PlayerList = StaticResources.PlayerList.Count <= 1 ? GetDummyPlayerList() : StaticResources.PlayerList;
            StaticResources.user = StaticResources.user == null ? GetDummyPlayer() : StaticResources.user;
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
            List<Player> players = StaticResources.PlayerList;

            /*
                Fields == 2-4
                col == 0-9
                row == 0-9
            */

            Log log = StaticResources.log;
            int logCount = log.shotLog.Count;

            int field = 2;
            int col = 0;
            int row = 0;

            if (logCount > 0)
            {
                Coordinates coordinates = log.shotLog.Last().coordinates;

                if (coordinates.col == 9 && coordinates.row == 9 && coordinates.field == 4)
                    return null;

                col = (coordinates.col + 1) < 10 ? (coordinates.col + 1) : 0;

                int increase = col == 0 ? 1 : 0;
                row = (coordinates.row + increase) < 10 ? (coordinates.row + increase) : 0;

                increase = row == 0 && col == 0 ? 1 : 0;
                field = (coordinates.field + increase) < 10 ? (coordinates.field + increase) : 0;
            }

            Random rnd = new Random();
            int hit = rnd.Next(0, 2);

            GameResponse response = new GameResponse()
            {
                playerId = players[1].PlayerId,
                fieldNumber = field,
                coordinates = new Coordinates() { field = field, col = col, row = row },
                hit = hit == 0 ? true : false
            };

            return response;
        }

        public List<Player> GetDummyPlayerList()
        {
            List<Player> players = new List<Player>(){
                new Player() { PlayerId = 1, name = "Zoë", ready = true, orderNumber = 1, type = PlayerType.Host },
                new Player() { PlayerId = 2, name = "Lean", ready = true, orderNumber = 2, type = PlayerType.Guest },
                new Player() { PlayerId = 3, name = "Martin", ready = true, orderNumber = 3, type = PlayerType.Guest },
                new Player() { PlayerId = 4, name = "Maikel", ready = true, orderNumber = 4, type = PlayerType.Guest }
            };

            return players;
        }

        public PlayerField GetMyDummyField()
        {
            PlayerField myField = new PlayerField()
            {
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
            Player player = new Player() { PlayerId = 1, name = "Zoë", ready = true, orderNumber = 1, type = PlayerType.Host };

            return player;
        }
    }
}