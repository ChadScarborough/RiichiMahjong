using RMU.Tiles;
using RMU.Algorithms;
using RMU.Globals;
using System.Collections.Generic;

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
                Enums.MAN, Enums.MAN, Enums.MAN,
                Enums.MAN, Enums.MAN, Enums.MAN,
                Enums.PIN, Enums.PIN, Enums.PIN,
                Enums.PIN, Enums.PIN, Enums.PIN,
                Enums.SOU
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
