//using Entities.Models;
//using GameLogic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;

//namespace UnitTests
//{
//    [TestClass]
//    public class PlayerFieldTests
//    {
//        [TestMethod]
//        public void CheckForHit_Happy_Hit()
//        {
//            PlayerField playerField = GetMyDummyField();
//            Coordinate coordinates = new Coordinate()
//            {
//                row = 1,
//                col = 1,
//                field = 1
//            };

//            bool result = playerField.CheckForHit(coordinates);

//            Assert.IsTrue(result);
//        }
        
//        [TestMethod]
//        public void CheckForHit_Happy_Mis()
//        {
//            PlayerField playerField = GetMyDummyField();
//            Coordinate coordinates = new Coordinate()
//            {
//                row = 2,
//                col = 1,
//                field = 1
//            };

//            bool result = playerField.CheckForHit(coordinates);

//            Assert.IsFalse(result);
//        }

//    }
//}
