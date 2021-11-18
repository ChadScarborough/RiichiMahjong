using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Algorithms
{
    public class BubbleSort : ISortingAlgorithm
    {
        public List<TileObject> SortHand(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority)
        {
            int size = Tiles.Count;
            int counter = 0;
            do
            {
                IterateThroughList(Tiles, SuitPriority, size);
                counter++;

            } while (counter < size);

            return Tiles;
        }

        private void IterateThroughList(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority, int size)
        {
            for (int i = 0; i < size - 1; i++)
            {
                CompareTiles(Tiles, SuitPriority, i);
            }
        }

        private void CompareTiles(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority, int index)
        {
            if (SuitPriority.IndexOf(Tiles[index].GetSuit()) > SuitPriority.IndexOf(Tiles[index + 1].GetSuit()))
            {
                SwapTiles(Tiles, index);
            }
            else if ((Tiles[index].GetValue() > Tiles[index + 1].GetValue()) && Tiles[index].GetSuit() == Tiles[index + 1].GetSuit())
            {
                SwapTiles(Tiles, index);
            }
        }

        private void SwapTiles(List<TileObject> Tiles, int index)
        {
            TileObject temp = Tiles[index + 1];
            Tiles[index + 1] = Tiles[index];
            Tiles[index] = temp;
        }
    }
}
