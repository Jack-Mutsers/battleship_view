using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Coordinates
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
    }
}
