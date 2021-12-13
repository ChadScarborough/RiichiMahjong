using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using System;

namespace RMU.Shanten
{
    public class ManTileCollection : AbstractTileCollection
    {
        public ManTileCollection(List<TileObject> _tiles)
        {
            InitializeValues(_tiles);
            CheckThatAllTilesAreOfTheCorrectSuit(_tiles);
        }

        private void CheckThatAllTilesAreOfTheCorrectSuit(List<TileObject> _tiles)
        {
            foreach (TileObject tile in _tiles)
            {
                CheckThatTileIsOfCorrectSuit(tile);
            }
        }

        private void InitializeValues(List<TileObject> _tiles)
        {
            SetSuit();
            this._tiles = _tiles;
        }

        private void CheckThatTileIsOfCorrectSuit(TileObject tile)
        {
            if (tile.GetSuit() == _suit)
            {
                throw new ArgumentException();
            }
        }

        public ManTileCollection()
        {
            SetSuit();
            _tiles = new List<TileObject>();
        }

        protected override void SetSuit()
        {
            this._suit = Enums.MAN;
        }
    }
}
