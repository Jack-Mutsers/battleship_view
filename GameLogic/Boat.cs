using Contracts;
using Entities.Models;
using Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Boat : IBoat
    {
        private List<ICoordinate> _coordinates { get; set; } = new List<ICoordinate>();
        public IEnumerable<ICoordinate> coordinates { get { return _coordinates; } }

        public void FillWithCoordinates(List<ICoordinate> coordinates)
        {

            if (coordinates == null)
                throw new ArgumentNullException("coordinates list");

            foreach (Coordinate coordinate in coordinates)
            {
                if (coordinate == null)
                    throw new ArgumentNullException("coordinate");

                coordinate.field = StaticResources.user.orderNumber;

                if (coordinate.validateCoordinates() == false)
                    throw new ArgumentException("invalid coordinates");

                _coordinates.Add(coordinate);
            }
        }
    }
}
