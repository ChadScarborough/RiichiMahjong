using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands;
using RMU.Hands.TestHands;
using static RMU.Shanten.HandSplitter.HandSplitter;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMUTests.ShantenTests
{
    [TestClass]
    public class HandSplitterTest
    {
        [TestMethod]
        public void HandSplitter_DoesNotReturnNull_WhenGivenTilesAsInput()
        {
            Hand hand = new OpenTestHand();
            List<TileCollection> collections = SplitHandBySuit(hand.GetClosedTiles());
            Assert.IsNotNull(collections);
        }

        [TestMethod]
        public void HandSplitter_SplitsHandTilesBySuit()
        {
            Hand hand = new OpenTestHand();
            List<TileCollection> collections = SplitHandBySuit(hand.GetClosedTiles());
            TileCollection man = collections[0];
            TileCollection pin = collections[1];
            TileCollection sou = collections[2];
            TileCollection wind = collections[3];
            TileCollection dragon = collections[4];
            foreach(TileObject tile in man.GetTiles())
            {
                Assert.AreEqual(MAN, tile.GetSuit());
            }
            Assert.AreEqual(3, man.GetTiles().Count);
            foreach(TileObject tile in pin.GetTiles())
            {
                Assert.AreEqual(PIN, tile.GetSuit());
            }
            Assert.AreEqual(7, pin.GetTiles().Count);
            foreach(TileObject tile in sou.GetTiles())
            {
                Assert.AreEqual(SOU, tile.GetSuit());
            }
            Assert.AreEqual(3, sou.GetTiles().Count);
            Assert.AreEqual(0, wind.GetTiles().Count);
            Assert.AreEqual(0, dragon.GetTiles().Count);
        }
    }
}
