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
    public class DeadWallTest
    {
        public IWall wall = new StandardWall();
        public IDeadWall deadWall;
        
        [TestMethod]
        public void DoraIndicatorsList_IsNotEmpty()
        {
            deadWall = new StandardDeadWall(wall);
            Assert.AreNotEqual(0, deadWall.GetDoraIndicators().Count);
        }

        [TestMethod]
        public void DoraIndicatorsList_ContainsFiveTiles()
        {
            deadWall = new StandardDeadWall(wall);
            Assert.AreEqual(5, deadWall.GetDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealedDoraIndicatorsList_ContainsOneTile()
        {
            deadWall = new StandardDeadWall(wall);
            Assert.AreEqual(1, deadWall.GetRevealedDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealDoraIndicatorMethod_AddsNewRevealedDoraIndicator()
        {
            deadWall = new StandardDeadWall(wall);
            Assert.AreEqual(1, deadWall.GetRevealedDoraIndicators().Count);
            deadWall.RevealDoraTile();
            Assert.AreEqual(2, deadWall.GetRevealedDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealingFiveNewDoraIndicators_ThrowsException()
        {
            Exception ex = null;
            deadWall = new StandardDeadWall(wall);
            try
            {
                deadWall.RevealDoraTile();
                deadWall.RevealDoraTile();
                deadWall.RevealDoraTile();
                deadWall.RevealDoraTile();
            }
            catch(Exception ExpectedException)
            {
                ex = ExpectedException;
            }
            Assert.IsNull(ex);
            try
            {
                deadWall.RevealDoraTile();
            }
            catch(Exception ExpectedException)
            {
                ex = ExpectedException;
            }
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DrawingTile_ReducesDrawableTileCount()
        {
            deadWall = new StandardDeadWall(wall);
            Assert.AreEqual(4, deadWall.GetDrawableTiles().Count);
            deadWall.DrawTile();
            Assert.AreEqual(3, deadWall.GetDrawableTiles().Count);
        }

        [TestMethod]
        public void ClearingDeadWall_AndRepopulatingIt_ProperlyFillsAllLists()
        {
            deadWall = new StandardDeadWall(wall);
            deadWall.Clear();
            deadWall.PopulateDeadWall();
            Assert.AreEqual(5, deadWall.GetDoraIndicators().Count);
            Assert.AreEqual(1, deadWall.GetRevealedDoraIndicators().Count);
            Assert.AreEqual(4, deadWall.GetDrawableTiles().Count);
            Assert.AreEqual(5, deadWall.GetUraDoraIndicators().Count);
        }
    }
}
