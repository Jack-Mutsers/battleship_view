using Contracts;
using Entities.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Resources
{
    public static class StaticResources
    {
        public static Player user { get; set; }
        public static List<Player> PlayerList { get; set; } = new List<Player>();
        public static string sessionCode { get; set; } = "";
        public static IPlayerField field { get; set; }
        public static ChangeLog log { get; set; } = new ChangeLog();
        public static bool startLobby { get; set; } = false;
        public static bool startGame { get; set; } = false;
        public static bool lobbyStarted { get; set; } = false;
        public static HighscoreRecords records { get; set; } = new HighscoreRecords();
        public static List<ServiceBusLog> sevicebusLogs { get; set; } = new List<ServiceBusLog>();

        public static List<Player> dummyPlayers = new List<Player>(){
            new Player() { PlayerId = 1, name = "Zoë", ready = true, orderNumber = 1, type = PlayerType.Host },
            new Player() { PlayerId = 2, name = "Lean", ready = true, orderNumber = 2, type = PlayerType.Guest },
            //new Player() { PlayerId = 3, name = "Martin", ready = true, orderNumber = 3, type = PlayerType.Guest },
            //new Player() { PlayerId = 4, name = "Maikel", ready = true, orderNumber = 4, type = PlayerType.Guest }
        };
    }
}
