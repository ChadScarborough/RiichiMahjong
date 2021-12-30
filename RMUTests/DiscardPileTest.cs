using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.DiscardPile;
using RMU.Globals;


namespace RMUTests
{
    [TestClass]
    public class DiscardPileTest
    {
        private IDiscardPile discardPile = new StandardDiscardPile();

        [TestMethod]
        public void DiscardPileIsEmpty_OnInitialization()
        {
            Assert.AreEqual(0, discardPile.GetDisplayedTileCount());
            Assert.AreEqual(0, discardPile.GetTotalDiscardedCount());
        }

        [TestMethod]
        public void DiscardPileContainsOneTile_AfterOneDiscard()
        {
            TileObject tile = TileFactory.CreateTile(2, Enums.Suit.Sou);

            discardPile.DiscardTile(tile);
            Assert.AreEqual(1, discardPile.GetDisplayedTileCount());
            Assert.AreEqual(1, discardPile.GetTotalDiscardedCount());
        }

        [TestMethod]
        public void DiscardPileRetainsDiscardedTiles_AfterBeingCalled()
        {
            TileObject tile = TileFactory.CreateTile(2, Enums.Suit.Sou);

            discardPile.DiscardTile(tile);
            discardPile.CallTile();
            Assert.AreEqual(0, discardPile.GetDisplayedTileCount());
            Assert.AreEqual(1, discardPile.GetTotalDiscardedCount());
        }
    }
}
