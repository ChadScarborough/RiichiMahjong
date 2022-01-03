using System;
using System.Collections.Generic;
using RMU.Tiles;
using static RMU.Globals.Enums;
using RMU.Shanten.HandSplitter;

namespace RMU.Globals.Algorithms
{
    public static class CountingSortForCollections
    {
        public static TileCollection SortCollection(TileCollection collection)
        {
            List<TileObject> tiles = collection.GetTiles();
            if (tiles.Count == 0) return collection;
            List<TileObject> outputList = new List<TileObject>();
            Suit suit = tiles[0].GetSuit();
            int[] quantities = new int[9];
            foreach(TileObject tile in tiles)
            {
                int value = tile.GetValue();
                quantities[value - 1]++;
            }
            for(int i = 0; i < 9; i++)
            {
                for(int j = quantities[i]; j > 0; j--)
                {
                    outputList.Add(TileFactory.CreateTile(i + 1, suit));
                }
            }
            switch (suit)
            {
                case MAN:
                    return new TileCollection(MAN, outputList);
                case PIN:
                    return new TileCollection(PIN, outputList);
                case SOU:
                    return new TileCollection(SOU, outputList);
                case WIND:
                    return new TileCollection(WIND, outputList);
                case DRAGON:
                    return new TileCollection(DRAGON, outputList);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
