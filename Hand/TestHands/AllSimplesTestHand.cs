using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.TestHands
{
    public class AllSimplesTestHand : TestHand
    {
        public AllSimplesTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new Algorithms.HandSorter();
            SetTileValues();
            SetTileSuits();
            FillHand();
        }

        private void SetTileSuits()
        {
            _tileSuits = new List<Enums.Suit>
            {
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Sou, Enums.Suit.Sou, Enums.Suit.Sou,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Man
            };
        }

        private void SetTileValues()
        {
            _tileValues = new List<int>
            {
                2, 3, 4,
                5, 5, 5,
                6, 7, 8,
                2, 2, 2,
                8
            };
        }
    }
}
