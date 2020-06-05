using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Boat : IBoat
    {
        private List<Coordinate> _coordinates { get; set; }
        public IEnumerable<Coordinate> coordinates { get; }

        public void FillWithCoordinates(List<Coordinate> coordinates)
        {

            if (coordinates == null)
                throw new ArgumentNullException("coordinates list");

            foreach (Coordinate coordinate in coordinates)
            {
                if (coordinate.validateCoordinates())
                    throw new ArgumentException("invalid coordinates");

                _coordinates.Add(coordinate);
            }
        }
    }
}
