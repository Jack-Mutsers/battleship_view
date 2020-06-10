using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Log
    {
        public List<GameResponse> shotLog { get; set; } = new List<GameResponse>();
        public List<string> gameLog { get; set; } = new List<string>();
        public bool MyTurn { get; set; }
        public int Turn { get; set; } = 1;
        public int Time { get; set; } = 0;
    }
}
