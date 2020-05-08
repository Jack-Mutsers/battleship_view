using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.models
{
    public class GameResponse
    {
        public Guid playerId { get; set; }
        public int fieldNumber { get; set; }
        public Coordinates coordinates { get; set; }
        public bool hit { get; set; }

    }

}
