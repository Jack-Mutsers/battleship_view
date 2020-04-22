using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBus.Entities.models;
using battleship_view.Models;

namespace battleship_view.classes
{
    public class Shot
    {
        public Coordinates FiredCoordinate;
        public MyField DummyField { get; private set; }

        public Shot(Coordinates coordinate, MyField dummyField)
        {
            FiredCoordinate = coordinate;
            DummyField = dummyField;
        }


        public bool CheckForHit()
        {
            foreach (var boat in DummyField.boats)
            {
                foreach (var coordinate in boat.coordinates)
                {
                    if (FiredCoordinate.row == coordinate.row && FiredCoordinate.col == coordinate.col)
                    {
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
