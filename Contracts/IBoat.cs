using System.Collections.Generic;

namespace Contracts
{
    public interface IBoat
    {
        public IEnumerable<ICoordinate> coordinates { get; }

        public void FillWithCoordinates(List<ICoordinate> coordinates);
    }
}
