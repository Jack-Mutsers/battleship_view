using Contracts;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class GameResponse
    {
        public int playerId { get; set; }
        public int senderId { get; set; }
        public int fieldNumber { get; set; }
        public Coordinate coordinates { get; set; }
        public bool hit { get; set; }
        public bool gameOver { get; set; }

    }

}
