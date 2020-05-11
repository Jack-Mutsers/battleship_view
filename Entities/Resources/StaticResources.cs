using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Resources
{
    public static class StaticResources
    {
        public static Player user { get; set; } = new Player();
        public static List<Player> PlayerList { get; set; } = new List<Player>();
        public static string sessionCode { get; set; } = "";
        public static PlayerField field { get; set; } = new PlayerField();
    }
}
