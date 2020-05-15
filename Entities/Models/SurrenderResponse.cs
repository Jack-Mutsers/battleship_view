using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class SurrenderResponse
    {
        public int playerId { get; set; }
        public PlayerField field { get; set; }
    }
}
