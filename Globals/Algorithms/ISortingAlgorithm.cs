using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Globals.Algorithms;

public interface ISortingAlgorithm
{
    List<Tile> SortHand(List<Tile> tiles, List<Enums.Suit> suitPriority);
}
