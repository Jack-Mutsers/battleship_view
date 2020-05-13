﻿using battleship_view.Models;
using Entities.Models;

namespace battleship_view.classes
{
    public class Shot
    {
        public Coordinates FiredCoordinate;
        public PlayerField DummyField { get; private set; }

        public Shot(Coordinates coordinate, PlayerField dummyField)
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