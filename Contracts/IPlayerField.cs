using System.Collections.Generic;

namespace Contracts
{
    public interface IPlayerField
    {
        public IEnumerable<IBoat> boats { get; }

        public List<ICoordinate> hitList { get; set; }
        public int fieldNumber { get; set; }

        public bool CheckForHit(ICoordinate shotCoordinate);

        public bool CheckForGameOver();
    }
}
