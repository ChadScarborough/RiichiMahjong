using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using System;
using RMU.Globals;

namespace RMUTests
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void NumberTileReturnsValueAssignedToIt()
        {
            TileObject tile = TileFactory.CreateTile(2, Enums.Suit.Man);

            Assert.AreEqual(2, tile.GetValue());
        }

        [TestMethod]
        public void DragonTileReturnsValueAssignedToIt()
        {
            TileObject tile = TileFactory.CreateTile(ConstValues.RED_DRAGON, Enums.Suit.Dragon);

            Assert.AreEqual(ConstValues.RED_DRAGON, tile.GetValue());
        }

        [TestMethod]
        public void WindTileReturnsValueAssignedToIt()
        {
            TileObject tile = TileFactory.CreateTile(ConstValues.WEST_WIND, Enums.Suit.Wind);

            Assert.AreEqual(ConstValues.WEST_WIND, tile.GetValue());
        }

        [TestMethod]
        public void TilesReturnCorrectSuits()
        {
            TileObject manTile = TileFactory.CreateTile(3, Enums.Suit.Man);
            TileObject pinTile = TileFactory.CreateTile(5, Enums.Suit.Pin);
            TileObject souTile = TileFactory.CreateTile(6, Enums.Suit.Sou);
            TileObject windTile = TileFactory.CreateTile(ConstValues.NORTH_WIND, Enums.Suit.Wind);
            TileObject dragonTile = TileFactory.CreateTile(ConstValues.WHITE_DRAGON, Enums.Suit.Dragon);

            Assert.AreEqual(Enums.Suit.Man, manTile.GetSuit());
            Assert.AreEqual(Enums.Suit.Pin, pinTile.GetSuit());
            Assert.AreEqual(Enums.Suit.Sou, souTile.GetSuit());
            Assert.AreEqual(Enums.Suit.Wind, windTile.GetSuit());
            Assert.AreEqual(Enums.Suit.Dragon, dragonTile.GetSuit());
        }

        [TestMethod]
        public void NumberTileThrowsExceptionOnInvalidValue()
        {
            Exception ex = null;

            try
            {
                TileObject tile = TileFactory.CreateTile(12, Enums.Suit.Pin);
            }
            catch (Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void WindTileThrowsExceptionOnInvalidValue()
        {
            Exception ex = null;

            try
            {
                TileObject tile = TileFactory.CreateTile(5, Enums.Suit.Wind);
            }
            catch (Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DragonTileThrowsExceptionOnInvalidValue()
        {
            Exception ex = null;

            try
            {
                TileObject tile = TileFactory.CreateTile(4, Enums.Suit.Dragon);
            }
            catch (Exception ExpectedException)
            {
                ex = ExpectedException;
            }

            Assert.IsNotNull(ex);
        }
    }
}
