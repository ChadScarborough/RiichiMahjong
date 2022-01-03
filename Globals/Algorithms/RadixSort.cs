using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Globals.Algorithms
{
    public class RadixSort : ISortingAlgorithm
    {
        private const int UNIQUE_NUMBERS = 9;
        private const int UNIQUE_SUITS = 5;
        private readonly List<DataStructures.Queue<TileObject>> _numberBuckets;
        private readonly List<DataStructures.Queue<TileObject>> _suitBuckets;
        public RadixSort()
        {
            _numberBuckets = new List<DataStructures.Queue<TileObject>>();
            _suitBuckets = new List<DataStructures.Queue<TileObject>>();
            CreateBuckets(_numberBuckets, UNIQUE_NUMBERS);
            CreateBuckets(_suitBuckets, UNIQUE_SUITS);
        }

        private void CreateBuckets(List<DataStructures.Queue<TileObject>> buckets, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                DataStructures.Queue<TileObject> queue = new DataStructures.Queue<TileObject>();
                buckets.Add(queue);
            }
        }

        public List<TileObject> SortHand(List<TileObject> tiles, List<Enums.Suit> suitPriority)
        {
            SortTilesByNumber(tiles);
            SortTilesBySuit(tiles, suitPriority);
            return tiles;
        }

        private void SortTilesBySuit(List<TileObject> tiles, List<Enums.Suit> suitPriority)
        {
            FillSuitBuckets(tiles, suitPriority);
            tiles.Clear();
            EmptyBuckets(tiles, _suitBuckets);
        }

        private void FillSuitBuckets(List<TileObject> tiles, List<Enums.Suit> suitPriority)
        {
            foreach (TileObject tile in tiles)
            {
                Enums.Suit suit = tile.GetSuit();
                int index = suitPriority.IndexOf(suit);
                _suitBuckets[index].Enqueue(tile);
            }
        }

        private void SortTilesByNumber(List<TileObject> tiles)
        {
            FillNumberBuckets(tiles);
            tiles.Clear();
            EmptyBuckets(tiles, _numberBuckets);
        }

        private void FillNumberBuckets(List<TileObject> tiles)
        {
            foreach (TileObject tile in tiles)
            {
                int index = tile.GetValue() - 1;
                _numberBuckets[index].Enqueue(tile);
            }
        }

        private static void EmptyQueues(List<TileObject> tiles, DataStructures.Queue<TileObject> queue)
        {
            while (!queue.IsEmpty())
            {
                TileObject tile = queue.Dequeue();
                tiles.Add(tile);
            }
        }

        private void EmptyBuckets(List<TileObject> tiles, List<DataStructures.Queue<TileObject>> buckets)
        {
            foreach (DataStructures.Queue<TileObject> queue in buckets)
            {
                EmptyQueues(tiles, queue);
            }
        }
    }
}
