using RMU.Tiles;
using RMU.Algorithms;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.TestHands
{
    public class AllTerminalsTestHand : TestHand
    {
        public AllTerminalsTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new HandSorter();
            SetTileValues();
            SetTileSuits();
            FillHand();
        }

        private void SetTileSuits()
        {
            _tileSuits = new List<Enums.Suit>()
            {
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Pin, Enums.Suit.Pin, Enums.Suit.Pin,
                Enums.Suit.Sou
            };
        }

        private void SetTileValues()
        {
            _tileValues = new List<int>
            {
                1, 1, 1,
                9, 9, 9,
                1, 1, 1,
                9, 9, 9,
                1
            };
        }
    }
}
