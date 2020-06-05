using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface ICoordinate
    {
        public int row { get; set; }
        public int col { get; set; }
        public int field { get; set; }
        public bool validateCoordinates();
    }
}
