using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using System;
using RMU.Globals;
using static RMU.Globals.StandardTileList;

namespace RMUTests
{
    [TestClass]
    public class TileTest
    {
        [TestMethod]
        public void NumberTileReturnsValueAssignedToIt()
        {
            Tile tile = TileFactory.CreateTile(2, Enums.Suit.Man);

            Assert.AreEqual(2, tile.GetValue());
        }

        [TestMethod]
        public void DragonTileReturnsValueAssignedToIt()
        {
            Tile tile = TileFactory.CreateTile(ConstValues.RED_DRAGON_C, Enums.Suit.Dragon);

            Assert.AreEqual(ConstValues.RED_DRAGON_C, tile.GetValue());
        }

        [TestMethod]
        public void WindTileReturnsValueAssignedToIt()
        {
            Tile tile = TileFactory.CreateTile(ConstValues.WEST_WIND_C, Enums.Suit.Wind);

            Assert.AreEqual(ConstValues.WEST_WIND_C, tile.GetValue());
        }

        [TestMethod]
        public void TilesReturnCorrectSuits()
        {
            Tile manTile = TileFactory.CreateTile(3, Enums.Suit.Man);
            Tile pinTile = TileFactory.CreateTile(5, Enums.Suit.Pin);
            Tile souTile = TileFactory.CreateTile(6, Enums.Suit.Sou);
            Tile windTile = TileFactory.CreateTile(ConstValues.NORTH_WIND_C, Enums.Suit.Wind);
            Tile dragonTile = TileFactory.CreateTile(ConstValues.WHITE_DRAGON_C, Enums.Suit.Dragon);

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
                TileFactory.CreateTile(12, Enums.Suit.Pin);
            }
            catch (Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void WindTileThrowsExceptionOnInvalidValue()
        {
            Exception ex = null;

            try
            {
                TileFactory.CreateTile(5, Enums.Suit.Wind);
            }
            catch (Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void DragonTileThrowsExceptionOnInvalidValue()
        {
            Exception ex = null;

            try
            {
                TileFactory.CreateTile(4, Enums.Suit.Dragon);
            }
            catch (Exception expectedException)
            {
                ex = expectedException;
            }

            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void RedFiveMan_IsRedFive()
        {
            Assert.IsTrue(RedFiveMan().IsRedFive());
        }

        [TestMethod]
        public void RedFivePin_IsRedFive()
        {
            Assert.IsTrue(RedFivePin().IsRedFive());
        }

        [TestMethod]
        public void RedFiveSou_IsRedFive()
        {
            Assert.IsTrue(RedFiveSou().IsRedFive());
        }
    }
}
