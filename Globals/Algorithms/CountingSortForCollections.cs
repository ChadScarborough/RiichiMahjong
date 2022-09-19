using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Globals.Algorithms;

public static class CountingSortForCollections
{
    private static readonly object sortLock = new();

    public static TileCollection SortCollection(TileCollection collection)
    {
        lock (sortLock)
        {
            return LockedSortCollection(collection);
        }
    }

    public static TileCollection LockedSortCollection(TileCollection collection)
    {
        List<Tile> tiles = collection.GetTiles();
        if (tiles.Count == 0)
        {
            return collection;
        }

        List<Tile> outputList = new();
        Suit suit = tiles[0].GetSuit();
        int[] quantities = new int[9];
        foreach (Tile tile in tiles)
        {
            int value = tile.GetValue();
            quantities[value - 1]++;
        }
        for (int i = 0; i < 9; i++)
        {
            for (int j = quantities[i]; j > 0; j--)
            {
                outputList.Add(TileFactory.CreateTile(i + 1, suit));
            }
        }
        return suit switch
        {
            MAN => new TileCollection(MAN, outputList),
            PIN => new TileCollection(PIN, outputList),
            SOU => new TileCollection(SOU, outputList),
            WIND => new TileCollection(WIND, outputList),
            DRAGON => new TileCollection(DRAGON, outputList),
            _ => throw new ArgumentException("Invalid suit"),
        };
    }
}
