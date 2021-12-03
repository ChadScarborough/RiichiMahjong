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
                Enums.MAN, Enums.MAN, Enums.MAN,
                Enums.PIN, Enums.PIN, Enums.PIN,
                Enums.SOU, Enums.SOU, Enums.SOU,
                Enums.PIN, Enums.PIN, Enums.PIN,
                Enums.MAN
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
