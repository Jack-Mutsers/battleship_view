using System;
using System.Collections.Generic;
using System.Text;
using Contracts;

namespace Entities.Models
{
    public class Log
    {
        public List<ShotLog> shotLog { get; set; } = new List<ShotLog>();
        public List<string> gameLog { get; set; } = new List<string>();
    }
}
