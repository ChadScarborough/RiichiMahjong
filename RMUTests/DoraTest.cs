using RMU.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles.TileDecorators;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;

namespace RMUTests
{
    [TestClass]
    public class DoraTest
    {
        private TileObject _tile;

        private void Setup()
        {
            _tile = WhiteDragon();
        }

        [TestMethod]
        public void DecoratorRetainsOriginalValue_OfDecoratedTile()
        {
            Setup();
            _tile = new DoraDecorator(_tile);
            Assert.IsTrue(AreTilesEquivalent(WhiteDragon(), _tile));
        }

        [TestMethod]
        public void AddingOneDoraDecorator_GivesTileDoraValueOne()
        {
            Setup();
            Assert.AreEqual(0, _tile.GetDoraValue());
            _tile = new DoraDecorator(_tile);
            Assert.AreEqual(1, _tile.GetDoraValue());
        }

        [TestMethod]
        public void AddingFiveDoraDecorators_GivesTileDoraValueFive()
        {
            Setup();
            for(int i = 0; i < 5; i++)
            {
                _tile = new DoraDecorator(_tile);
            }
            Assert.AreEqual(5, _tile.GetDoraValue());
        }

        [TestMethod]
        public void AddDoraValueGlobalFunction_AddsDoraValueOne()
        {
            Setup();
            AddDoraValue(ref _tile);
            Assert.AreEqual(1, _tile.GetDoraValue());
        }

        [TestMethod]
        public void AddUraDoraValueGlobalFunction_AddsUraDoraValueOne()
        {
            Setup();
            AddUraDoraValue(ref _tile);
            Assert.AreEqual(1, _tile.GetUraDoraValue());
        }

        [TestMethod]
        public void IsDoraTileReturnsTrue_AfterBeingDecoratedByDoraDecorator()
        {
            Setup();
            Assert.IsFalse(_tile.IsDoraTile());
            AddDoraValue(ref _tile);
            Assert.IsTrue(_tile.IsDoraTile());
        }

        [TestMethod]
        public void IsDoraTileReturnsTrue_AfterBeingDecoratedByUraDoraDecorator()
        {
            Setup();
            Assert.IsFalse(_tile.IsDoraTile());
            AddUraDoraValue(ref _tile);
            Assert.IsTrue(_tile.IsDoraTile());
        }
    }
}
