using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Algorithms
{
    public interface ISortingAlgorithm
    {
        List<TileObject> SortHand(List<TileObject> Tiles, List<Enums.Suit> SuitPriority);
    }
}
