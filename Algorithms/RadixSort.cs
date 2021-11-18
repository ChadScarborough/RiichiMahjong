using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Algorithms
{
    public class RadixSort : ISortingAlgorithm
    {
        private const int UNIQUE_NUMBERS = 9;
        private const int UNIQUE_SUITS = 5;
        private List<DataStructures.Queue<TileObject>> NumberBuckets;
        private List<DataStructures.Queue<TileObject>> SuitBuckets;
        public RadixSort()
        {
            NumberBuckets = new List<DataStructures.Queue<TileObject>>();
            SuitBuckets = new List<DataStructures.Queue<TileObject>>();
            for(int i = 0; i < UNIQUE_NUMBERS; i++)
            {
                NumberBuckets.Add(new DataStructures.Queue<TileObject>());
            }
            for(int i = 0; i < UNIQUE_SUITS; i++)
            {
                SuitBuckets.Add(new DataStructures.Queue<TileObject>());
            }
         }

        public List<TileObject> SortHand(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority)
        {
            SortTilesByNumber(Tiles);
            SortTilesBySuit(Tiles, SuitPriority);
            return Tiles;
        }

        private void SortTilesBySuit(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority)
        {
            FillSuitBuckets(Tiles, SuitPriority);
            Tiles.Clear();
            EmptyBuckets(Tiles, SuitBuckets);
        }

        private void FillSuitBuckets(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority)
        {
            foreach (TileObject tile in Tiles)
            {
                TileEnums.Suit suit = tile.GetSuit();
                int index = SuitPriority.IndexOf(suit);
                SuitBuckets[index].Enqueue(tile);
            }
        }

        private void SortTilesByNumber(List<TileObject> Tiles)
        {
            FillNumberBuckets(Tiles);
            Tiles.Clear();
            EmptyBuckets(Tiles, NumberBuckets);
        }

        private void FillNumberBuckets(List<TileObject> Tiles)
        {
            foreach (TileObject tile in Tiles)
            {
                int index = tile.GetValue() - 1;
                NumberBuckets[index].Enqueue(tile);
            }
        }

        private static void EmptyQueues(List<TileObject> Tiles, DataStructures.Queue<TileObject> queue)
        {
            while (!queue.IsEmpty())
            {
                TileObject tile = queue.Dequeue();
                Tiles.Add(tile);
            }
        }

        private void EmptyBuckets(List<TileObject> Tiles, List<DataStructures.Queue<TileObject>> buckets)
        {
            foreach (DataStructures.Queue<TileObject> queue in buckets)
            {
                EmptyQueues(Tiles, queue);
            }
        }
    }
}
