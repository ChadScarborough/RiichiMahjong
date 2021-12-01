using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;
using RMU.Algorithms;

namespace RMU.Hand.TestHands
{
    public class NineGatesTestHand : TestHand
    {
        public NineGatesTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new HandSorter();
            _tileValues = new List<int>
            {
                1, 1, 1,
                2, 3, 4,
                5, 6, 7,
                8, 9, 9,
                9
            };
            _tileSuits = new List<Enums.Suit>
            {
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man
            };
            FillHand();
        }
    }
}
