using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using RMU.Globals.Algorithms;

namespace RMUTests
{
    [TestClass]
    public class SortingTest
    {
        private readonly HandSorter _handSorter = new HandSorter();
        private List<TileObject> _tiles = new List<TileObject>();
        [TestMethod]
        public void HandSorter_CompilesProperly()
        {
            Assert.IsNotNull(_handSorter.SortHand(new List<TileObject>()));
        }

        [TestMethod]
        public void HandSorterProperlyReturnsList_OfSizeOne()
        {
            _tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            Assert.AreEqual(1, _handSorter.SortHand(_tiles).Count);
        }

        [TestMethod]
        public void ReturnsSortedList_WhenSortedListGivenAsInput()
        {
            _tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            _tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Man));
            _tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Sou));
            _tiles = _handSorter.SortHand(_tiles);
            Assert.AreEqual(1, _tiles[0].GetValue());
            Assert.AreEqual(3, _tiles[1].GetValue());
            Assert.AreEqual(2, _tiles[2].GetValue());
        }

        [TestMethod]
        public void ReturnsSortedList_WhenUnsortedListGivenAsInput()
        {
            _tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Sou));
            _tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Man));
            _tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Man));
            _tiles = _handSorter.SortHand(_tiles);
            Assert.AreEqual(1, _tiles[0].GetValue());
            Assert.AreEqual(3, _tiles[1].GetValue());
            Assert.AreEqual(2, _tiles[2].GetValue());
        }

        [TestMethod]
        public void TilesAreSorted_AccordingToUserSelectedSuitPriority()
        {
            _handSorter.SetSuitPriority(Enums.Suit.Sou, Enums.Suit.Man, Enums.Suit.Dragon, Enums.Suit.Pin, Enums.Suit.Wind);
            _tiles.Add(TileFactory.CreateTile(1, Enums.Suit.Dragon));
            _tiles.Add(TileFactory.CreateTile(2, Enums.Suit.Wind));
            _tiles.Add(TileFactory.CreateTile(3, Enums.Suit.Sou));
            _tiles.Add(TileFactory.CreateTile(4, Enums.Suit.Pin));
            _tiles.Add(TileFactory.CreateTile(5, Enums.Suit.Man));
            _tiles = _handSorter.SortHand(_tiles);
            Assert.AreEqual(3, _tiles[0].GetValue());
            Assert.AreEqual(5, _tiles[1].GetValue());
            Assert.AreEqual(1, _tiles[2].GetValue());
            Assert.AreEqual(4, _tiles[3].GetValue());
            Assert.AreEqual(2, _tiles[4].GetValue());
        }
    }
}
