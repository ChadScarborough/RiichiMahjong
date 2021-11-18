using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Algorithms
{
    public interface ISortingAlgorithm
    {
        List<TileObject> SortHand(List<TileObject> Tiles, List<TileEnums.Suit> SuitPriority);
    }
}
