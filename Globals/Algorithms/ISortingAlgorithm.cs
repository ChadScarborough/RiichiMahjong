using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Algorithms
{
    public interface ISortingAlgorithm
    {
        List<TileObject> SortHand(List<TileObject> Tiles, List<Enums.Suit> SuitPriority);
    }
}
