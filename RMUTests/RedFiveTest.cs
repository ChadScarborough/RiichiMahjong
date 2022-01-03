using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using static RMU.Globals.Functions;
using static RMU.Globals.StandardTileList;

namespace RMUTests
{
    [TestClass]
    public class RedFiveTest
    {
        private TileObject _tile;

        private void Setup()
        {
            _tile = FiveSou();
        }

        [TestMethod]
        public void RedFiveDecorator_CausesIsRedFiveToReturnTrue()
        {
            Setup();
            Assert.IsFalse(_tile.IsRedFive());
            MakeRedFive(ref _tile);
            Assert.IsTrue(_tile.IsRedFive());
        }

        [TestMethod]
        public void RedFiveDecorator_CausesIsDoraTileToReturnTrue()
        {
            Setup();
            Assert.IsFalse(_tile.IsDoraTile());
            MakeRedFive(ref _tile);
            Assert.IsTrue(_tile.IsDoraTile());
        }

        [TestMethod]
        public void RedFiveDecoratorThrowsException_WhenGivenANonFiveTile()
        {
            _tile = FourSou();
            Exception exception = null;
            try
            {
                MakeRedFive(ref _tile);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void RedFiveTileRemainsRedFive_AfterBeingDecoratedWithDoraDecorator()
        {
            Setup();
            MakeRedFive(ref _tile);
            AddDoraValue(ref _tile);
            Assert.IsTrue(_tile.IsRedFive());
        }

        [TestMethod]
        public void RedFiveTileRemainsRedFive_AfterBeingDecoratedWithUraDoraDecorator()
        {
            Setup();
            MakeRedFive(ref _tile);
            AddUraDoraValue(ref _tile);
            Assert.IsTrue(_tile.IsRedFive());
        }
    }
}
