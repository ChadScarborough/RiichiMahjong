using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMUTests
{
    [TestClass]
    public class WallTest
    {
        IWall wall = new StandardWall();
        IWall redFivesWall = new StandardWall_ThreeRedFives();

        [TestMethod]
        public void FillWallMethod_CreatesWallWith136Tiles()
        {
            Assert.AreEqual(136, wall.GetSize());
        }

        [TestMethod]
        public void RedFivesWall_GeneratesCorrectly()
        {
            Assert.AreEqual(136, redFivesWall.GetSize());
        }
    }
}
