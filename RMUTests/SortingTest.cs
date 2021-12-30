using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.DataStructures;
using System;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using RMU.Algorithms;

namespace RMUTests
{
    [TestClass]
    public class SortingTest
    {
        private HandSorter handSorter = new HandSorter();
        private List<TileObject> tiles = new List<TileObject>();
        [TestMethod]
        public void HandSorter_CompilesProperly()
        {
            Assert.IsNotNull(handSorter.SortHand(new List<TileObject>()));
        }

        [TestMethod]
        public void HandSorterProperlyReturnsList_OfSizeOne()
        {
            tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            Assert.AreEqual(1, handSorter.SortHand(tiles).Count);
        }

        [TestMethod]
        public void ReturnsSortedList_WhenSortedListGivenAsInput()
        {
            tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Man));
            tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Sou));
            tiles = handSorter.SortHand(tiles);
            Assert.AreEqual(1, tiles[0].GetValue());
            Assert.AreEqual(3, tiles[1].GetValue());
            Assert.AreEqual(2, tiles[2].GetValue());
        }

        [TestMethod]
        public void ReturnsSortedList_WhenUnsortedListGivenAsInput()
        {
            tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Sou));
            tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Man));
            tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            tiles = handSorter.SortHand(tiles);
            Assert.AreEqual(1, tiles[0].GetValue());
            Assert.AreEqual(3, tiles[1].GetValue());
            Assert.AreEqual(2, tiles[2].GetValue());
        }

        [TestMethod]
        public void TilesAreSorted_AccordingToUserSelectedSuitPriority()
        {
            handSorter.SetSuitPriority(Enums.Suit.Sou, Enums.Suit.Man, Enums.Suit.Dragon, Enums.Suit.Pin, Enums.Suit.Wind);
            tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Dragon));
            tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Wind));
            tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Sou));
            tiles.Add(TileFactory.CreateTile(4, Enums.Suit.Pin));
            tiles.Add(TileFactory.CreateTile(5, Enums.Suit.Man));
            tiles = handSorter.SortHand(tiles);
            Assert.AreEqual(3, tiles[0].GetValue());
            Assert.AreEqual(5, tiles[1].GetValue());
            Assert.AreEqual(1, tiles[2].GetValue());
            Assert.AreEqual(4, tiles[3].GetValue());
            Assert.AreEqual(2, tiles[4].GetValue());
        }
    }
}
