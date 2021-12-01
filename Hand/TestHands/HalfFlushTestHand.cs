using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.TestHands
{
    public class HalfFlushTestHand : TestHand
    {
        public HalfFlushTestHand()
        {
            _closedTiles = new List<TileObject>();
            _handSorter = new Algorithms.HandSorter();
            _tileValues = new List<int>
            {
                1, 1, 1,
                2, 3, 4,
                7, 8, 9,
                ConstValues.EAST_WIND, ConstValues.EAST_WIND, ConstValues.EAST_WIND,
                ConstValues.RED_DRAGON
            };
            _tileSuits = new List<Enums.Suit>
            {
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Man, Enums.Suit.Man, Enums.Suit.Man,
                Enums.Suit.Wind, Enums.Suit.Wind, Enums.Suit.Wind,
                Enums.Suit.Dragon
            };
            FillHand();
        }
    }
}
