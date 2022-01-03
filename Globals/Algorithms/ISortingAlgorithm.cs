using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Globals.Algorithms
{
    public interface ISortingAlgorithm
    {
        List<TileObject> SortHand(List<TileObject> tiles, List<Enums.Suit> suitPriority);
    }
}
