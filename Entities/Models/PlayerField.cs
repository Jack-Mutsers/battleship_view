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
        public List<Coordinates> hitList { get; set; } = new List<Coordinates>();
        public int fieldNumber { get; set; }

        public bool CheckForHit(Coordinates shotCoordinate)
        {
            foreach (var boat in boats)
            {
                foreach (var coordinate in boat.coordinates)
                {
                    if (coordinate.row == shotCoordinate.row && coordinate.col == shotCoordinate.col)
                    {
                        hitList.Add(shotCoordinate);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForGameOver()
        {
            bool gameOver = false;
            int coordinatesCount = 0;

            foreach (var boat in boats)
            {
                foreach (var coordinate in boat.coordinates)
                {
                    coordinatesCount++;
                }
            }

            if (coordinatesCount == hitList.Count)
            {
                gameOver = true;
            }

            return gameOver;
        }
    }
}
