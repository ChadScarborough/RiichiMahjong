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
            foreach (TileObject tile in Tiles)
            {
                TileEnums.Suit suit = tile.GetSuit();
                int index = SuitPriority.IndexOf(suit);
                SuitBuckets[index].Enqueue(tile);
            }
            Tiles.Clear();
            foreach (DataStructures.Queue<TileObject> queue in SuitBuckets)
            {
                EmptyQueues(Tiles, queue);
            }
        }

        private void SortTilesByNumber(List<TileObject> Tiles)
        {
            foreach (TileObject tile in Tiles)
            {
                NumberBuckets[tile.GetValue() - 1].Enqueue(tile);
            }
            Tiles.Clear();
            foreach (DataStructures.Queue<TileObject> queue in NumberBuckets)
            {
                EmptyQueues(Tiles, queue);
            }
        }

        private static void EmptyQueues(List<TileObject> Tiles, DataStructures.Queue<TileObject> queue)
        {
            while (!queue.IsEmpty())
            {
                Tiles.Add(queue.Dequeue());
            }
        }
    }
}
