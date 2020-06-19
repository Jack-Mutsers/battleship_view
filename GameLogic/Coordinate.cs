using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic
{
    public class Coordinate : ICoordinate
    {
        private int _row { get; set; }
        private int _col { get; set; }
        private int _field { get; set; }

        public int row 
        {
            get { return _row; } 
            set 
            { 
                if (value < 0) throw new ArgumentException("row");

                _row = value;
            } 
        }

        public int col
        {
            get { return _col; }
            set
            {
                if (value < 0) throw new ArgumentException("col");

                _col = value;
            }
        }

        public int field
        {
            get { return _field; }
            set
            {
                if (value < 0) throw new ArgumentException("field");

                _field = value;
            }
        }

        public bool validateCoordinates()
        {
            bool valid = true;
            if (row < 0 || row > 9)
                valid = false;

            if (col < 0 || col > 9)
                valid = false;

            if (field < 1 || field > 4)
                valid = false;

            return valid;
        }
    }
}
