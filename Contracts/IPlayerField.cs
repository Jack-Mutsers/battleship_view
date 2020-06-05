using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IPlayerField
    {
        public IEnumerable<IBoat> boats { get; }

        public List<Coordinate> hitList { get; set; }
        public int fieldNumber { get; set; }

        public bool CheckForHit(Coordinate shotCoordinate);

        public bool CheckForGameOver();
    }
}
