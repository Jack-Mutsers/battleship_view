using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities.Resources;

namespace Entities.Models
{
    public class Log
    {
        public List<ShotLog> shotLog { get; set; } = new List<ShotLog>();
        public List<string> gameLog { get; set; } = new List<string>();
        public int Turn { get; set; } = 1;
        public bool MyTurn { get; set; }
        public int Time { get; set; } = 0;
    }
}
