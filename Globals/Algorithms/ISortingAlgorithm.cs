using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Globals.Algorithms
{
    public interface ISortingAlgorithm
    {
        List<Tile> SortHand(List<Tile> tiles, List<Enums.Suit> suitPriority);
    }
}
