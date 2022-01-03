using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMUTests
{
    [TestClass]
    public class DeadWallTest
    {
        private readonly AbstractWall _wall = new FourPlayerWallNoRedFives();
        private IDeadWall _deadWall;
        
        [TestMethod]
        public void DoraIndicatorsList_IsNotEmpty()
        {
            _deadWall = new StandardDeadWall(_wall);
            Assert.AreNotEqual(0, _deadWall.GetDoraIndicators().Count);
        }

        [TestMethod]
        public void DoraIndicatorsList_ContainsFiveTiles()
        {
            _deadWall = new StandardDeadWall(_wall);
            Assert.AreEqual(5, _deadWall.GetDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealedDoraIndicatorsList_ContainsOneTile()
        {
            _deadWall = new StandardDeadWall(_wall);
            Assert.AreEqual(1, _deadWall.GetRevealedDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealDoraIndicatorMethod_AddsNewRevealedDoraIndicator()
        {
            _deadWall = new StandardDeadWall(_wall);
            Assert.AreEqual(1, _deadWall.GetRevealedDoraIndicators().Count);
            _deadWall.RevealDoraTile();
            Assert.AreEqual(2, _deadWall.GetRevealedDoraIndicators().Count);
        }

        [TestMethod]
        public void RevealingFiveNewDoraIndicators_ThrowsException()
        {
            Exception ex = null;
            _deadWall = new StandardDeadWall(_wall);
            try
            {
                _deadWall.RevealDoraTile();
                _deadWall.RevealDoraTile();
                _deadWall.RevealDoraTile();
                _deadWall.RevealDoraTile();
            }
            catch(Exception expectedException)
            {
                ex = expectedException;
            }
            Assert.IsNull(ex);
            try
            {
                _deadWall.RevealDoraTile();
            }
            catch(Exception expectedException)
            {
                ex = expectedException;
            }
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DrawingTile_ReducesDrawableTileCount()
        {
            _deadWall = new StandardDeadWall(_wall);
            Assert.AreEqual(4, _deadWall.GetDrawableTiles().Count);
            _deadWall.DrawTile();
            Assert.AreEqual(3, _deadWall.GetDrawableTiles().Count);
        }

        [TestMethod]
        public void ClearingDeadWall_AndRepopulatingIt_ProperlyFillsAllLists()
        {
            _deadWall = new StandardDeadWall(_wall);
            _deadWall.Clear();
            _deadWall.PopulateDeadWall();
            Assert.AreEqual(5, _deadWall.GetDoraIndicators().Count);
            Assert.AreEqual(1, _deadWall.GetRevealedDoraIndicators().Count);
            Assert.AreEqual(4, _deadWall.GetDrawableTiles().Count);
            Assert.AreEqual(5, _deadWall.GetUraDoraIndicators().Count);
        }
    }
}
