using Contracts;
using Entities.Models;
using Entities.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLogic
{
    public class PlayerField : IPlayerField
    {
        private List<IBoat> _boats { get; set; } = new List<IBoat>();
        public IEnumerable<IBoat> boats { get { return _boats; } }

        public List<ICoordinate> hitList { get; set; } = new List<ICoordinate>();
        public int fieldNumber { get; set; }

        public bool CheckForHit(ICoordinate shotCoordinate)
        {
            foreach (var boat in boats)
            {
                foreach (var coordinate in boat.coordinates)
                {
                    if (coordinate.row == shotCoordinate.row && coordinate.col == shotCoordinate.col)
                    {
                        hitList.Add(shotCoordinate);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckForGameOver()
        {
            bool gameOver = false;
            int coordinatesCount = 0;

            foreach (var boat in boats)
            {
                foreach (var coordinate in boat.coordinates)
                {
                    coordinatesCount++;
                }
            }

            if (coordinatesCount == hitList.Count)
            {
                gameOver = true;
            }

            return gameOver;
        }

        public void AddNewBoatToField(IBoat boat)
        {
            if (boat == null)
                throw new ArgumentNullException();

            if (CheckIfAllowed(boat.coordinates.Count()) == false)
                throw new ArgumentException();

            _boats.Add(boat);
        }

        private bool CheckIfAllowed(int size)
        {
            if (size < 2 || size > 5)
                return false;

            int fiveSquare = 1;
            int fourSquare = 1;
            int threeSquare = 2;
            int twoSquare = 1;

            //if (boats.Count() > 0)
            //{
                foreach (IBoat boat in boats)
                {
                    switch (boat.coordinates.Count())
                    {
                        case 2:
                            twoSquare--;
                            break;
                        case 3:
                            threeSquare--;
                            break;
                        case 4:
                            fourSquare--;
                            break;
                        case 5:
                            fiveSquare--;
                            break;
                    }
                }
            //}

            bool allowed = true;
            switch (size)
            {
                case 2:
                    if (twoSquare == 0)
                        allowed = false;
                    break;
                case 3:
                    if (threeSquare == 0)
                        allowed = false;
                    break;
                case 4:
                    if (fourSquare == 0)
                        allowed = false;
                    break;
                case 5:
                    if (fiveSquare == 0)
                        allowed = false;
                    break;
            }

            return allowed;
        }

    }
}
