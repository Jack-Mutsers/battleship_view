using Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class PlayerFieldTests
    {
        [TestMethod]
        public void CheckForHit_Happy_Hit()
        {
            PlayerField playerField = GetMyDummyField();
            Coordinates coordinates = new Coordinates()
            {
                row = 1,
                col = 1,
                field = 1
            };

            bool result = playerField.CheckForHit(coordinates);

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        public void CheckForHit_Happy_Mis()
        {
            PlayerField playerField = GetMyDummyField();
            Coordinates coordinates = new Coordinates()
            {
                row = 2,
                col = 1,
                field = 1
            };

            bool result = playerField.CheckForHit(coordinates);

            Assert.IsFalse(result);
        }

        public PlayerField GetMyDummyField()
        {
            PlayerField myField = new PlayerField()
            {
                fieldNumber = 1,
                boats = new List<Boat>()
                {
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 1, col = 1 }, new Coordinates() { field = 1, row = 1, col = 2 }, new Coordinates() { field = 1, row = 1, col = 3 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 4, col = 9 }, new Coordinates() { field = 1, row = 5, col = 9 }, new Coordinates() { field = 1, row = 6, col = 9 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 7, col = 7 }, new Coordinates() { field = 1, row = 7, col = 8 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 3, col = 4 }, new Coordinates() { field = 1, row = 4, col = 4 }
                        }
                    },
                    new Boat(){
                        coordinates = new List<Coordinates>()
                        {
                            new Coordinates() { field = 1, row = 9, col = 7 }, new Coordinates() { field = 1, row = 9, col = 8 }, new Coordinates() { field = 1, row = 9, col = 9 }
                        }
                    },
                }
            };

            return myField;
        }

    }
}