using Entities.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class CoordinatesTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestNegativeCoordinates()
        {
            Coordinate coordinates = new Coordinate()
            {
                row = -2,
                col = -1,
                field = -1
            };

        }

    }
}
