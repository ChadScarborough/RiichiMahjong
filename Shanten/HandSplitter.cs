using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Shanten
{
    public static class HandSplitter
    {
        private static AbstractTileCollection _manCollection, _pinCollection, _souCollection, _windCollection, _dragonCollection;

        public static List<AbstractTileCollection> SplitHandBySuit(List<TileObject> hand)
        {
            ClearTileCollections();
            foreach(TileObject tile in hand)
            {
                switch (tile.GetSuit())
                {
                    case Enums.Suit.Man:
                        _manCollection.AddTile(tile);
                        break;
                    case Enums.Suit.Pin:
                        _pinCollection.AddTile(tile);
                        break;
                    case Enums.Suit.Sou:
                        _souCollection.AddTile(tile);
                        break;
                    case Enums.Suit.Wind:
                        _windCollection.AddTile(tile);
                        break;
                    case Enums.Suit.Dragon:
                        _dragonCollection.AddTile(tile);
                        break;
                }
            }
            return new List<AbstractTileCollection> { _manCollection, _pinCollection, _souCollection, _windCollection, _dragonCollection };
        }

        private static void ClearTileCollections()
        {
            _manCollection.Clear();
            _pinCollection.Clear();
            _souCollection.Clear();
            _windCollection.Clear();
            _dragonCollection.Clear();
        }
    }
}
