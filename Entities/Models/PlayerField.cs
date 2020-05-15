using Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class PlayerField
    {
        public List<Boat> boats { get; set; }
        public int fieldNumber { get; set; }

        public bool CheckForHit(Coordinates shotCoordinate)
        {
            if (shotCoordinate.field == fieldNumber)
            {
                foreach (var boat in boats)
                {
                    foreach (var coordinate in boat.coordinates)
                    {
                        if (coordinate.row == shotCoordinate.row && coordinate.col == shotCoordinate.col)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
