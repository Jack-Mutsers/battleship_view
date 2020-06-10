using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string name { get; set; }
        public int orderNumber { get; set; } = 0;
        public bool ready { get; set; } = false;
        public PlayerType type { get; set; } = PlayerType.Guest;
        public bool GameOver { get; set; }
    }

}
