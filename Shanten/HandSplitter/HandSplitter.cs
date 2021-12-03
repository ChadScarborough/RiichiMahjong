using System.Collections.Generic;
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
                    case Enums.MAN:
                        _manCollection.AddTile(tile);
                        break;
                    case Enums.PIN:
                        _pinCollection.AddTile(tile);
                        break;
                    case Enums.SOU:
                        _souCollection.AddTile(tile);
                        break;
                    case Enums.WIND:
                        _windCollection.AddTile(tile);
                        break;
                    case Enums.DRAGON:
                        _dragonCollection.AddTile(tile);
                        break;
                }
            }
            return new List<AbstractTileCollection> 
            { 
                _manCollection, _pinCollection, _souCollection, _windCollection, _dragonCollection 
            };
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
