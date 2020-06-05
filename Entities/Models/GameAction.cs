using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GameAction
    {
        public int playerId { get; set; }
        public string sessionCode { get; set; }
        public Coordinate coordinates { get; set; }
        public PlayerAction action { get; set; }

    }

}
