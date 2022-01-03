using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using RMU.DiscardPile;
using RMU.Globals;


namespace RMUTests
{
    [TestClass]
    public class DiscardPileTest
    {
        private readonly IDiscardPile _discardPile = new StandardDiscardPile();

        [TestMethod]
        public void DiscardPileIsEmpty_OnInitialization()
        {
            Assert.AreEqual(0, _discardPile.GetDisplayedTileCount());
            Assert.AreEqual(0, _discardPile.GetTotalDiscardedCount());
        }

        [TestMethod]
        public void DiscardPileContainsOneTile_AfterOneDiscard()
        {
            TileObject tile = TileFactory.CreateTile(2, Enums.Suit.Sou);

            _discardPile.DiscardTile(tile);
            Assert.AreEqual(1, _discardPile.GetDisplayedTileCount());
            Assert.AreEqual(1, _discardPile.GetTotalDiscardedCount());
        }

        [TestMethod]
        public void DiscardPileRetainsDiscardedTiles_AfterBeingCalled()
        {
            TileObject tile = TileFactory.CreateTile(2, Enums.Suit.Sou);

            _discardPile.DiscardTile(tile);
            _discardPile.CallTile();
            Assert.AreEqual(0, _discardPile.GetDisplayedTileCount());
            Assert.AreEqual(1, _discardPile.GetTotalDiscardedCount());
        }
    }
}
