using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IBoat
    {
        public IEnumerable<Coordinate> coordinates { get; }

        public void FillWithCoordinates(List<Coordinate> coordinates);
    }
}
