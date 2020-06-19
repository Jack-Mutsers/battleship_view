using Contracts;
using Entities.Models;
using GameLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class SurrenderResponse
    {
        public int playerId { get; set; }
        public IPlayerField field { get; set; }
    }
}
