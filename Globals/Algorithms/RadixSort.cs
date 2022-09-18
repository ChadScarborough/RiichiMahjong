using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Globals.Algorithms;

public sealed class RadixSort : ISortingAlgorithm
{
    private const int UNIQUE_NUMBERS = 9;
    private const int UNIQUE_SUITS = 5;
    private readonly List<DataStructures.Queue<Tile>> _numberBuckets;
    private readonly List<DataStructures.Queue<Tile>> _suitBuckets;
    public RadixSort()
    {
        _numberBuckets = new List<DataStructures.Queue<Tile>>();
        _suitBuckets = new List<DataStructures.Queue<Tile>>();
        CreateBuckets(_numberBuckets, UNIQUE_NUMBERS);
        CreateBuckets(_suitBuckets, UNIQUE_SUITS);
    }

    private static void CreateBuckets(List<DataStructures.Queue<Tile>> buckets, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            DataStructures.Queue<Tile> queue = new();
            buckets.Add(queue);
        }
    }

    public List<Tile> SortHand(List<Tile> tiles, List<Suit> suitPriority)
    {
        SortTilesByNumber(tiles);
        SortTilesBySuit(tiles, suitPriority);
        return tiles;
    }

    private void SortTilesBySuit(List<Tile> tiles, List<Suit> suitPriority)
    {
        FillSuitBuckets(tiles, suitPriority);
        tiles.Clear();
        EmptyBuckets(tiles, _suitBuckets);
    }

    private void FillSuitBuckets(List<Tile> tiles, List<Suit> suitPriority)
    {
        foreach (Tile tile in tiles)
        {
            Suit suit = tile.GetSuit();
            int index = suitPriority.IndexOf(suit);
            _suitBuckets[index].Enqueue(tile);
        }
    }

    private void SortTilesByNumber(List<Tile> tiles)
    {
        FillNumberBuckets(tiles);
        tiles.Clear();
        EmptyBuckets(tiles, _numberBuckets);
    }

    private void FillNumberBuckets(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            int index = tile.GetValue() - 1;
            _numberBuckets[index].Enqueue(tile);
        }
    }

    private static void EmptyQueues(List<Tile> tiles, DataStructures.Queue<Tile> queue)
    {
        while (!queue.IsEmpty())
        {
            Tile tile = queue.Dequeue();
            tiles.Add(tile);
        }
    }

    private static void EmptyBuckets(List<Tile> tiles, List<DataStructures.Queue<Tile>> buckets)
    {
        foreach (DataStructures.Queue<Tile> queue in buckets)
        {
            EmptyQueues(tiles, queue);
        }
    }
}
