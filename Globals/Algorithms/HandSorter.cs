using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Globals.Algorithms;

public sealed class HandSorter
{
    private List<Suit> _suitPriority;
    private readonly ISortingAlgorithm _sortingAlgorithm;

    public HandSorter()
    {
        _suitPriority = new List<Suit>() { MAN, PIN, SOU, WIND, DRAGON };
        _sortingAlgorithm = new RadixSort();
    }
    public List<Tile> SortHand(List<Tile> list)
    {
        if (list.Count > 1)
        {
            _ = _sortingAlgorithm.SortHand(list, _suitPriority);
        }
        return list;
    }

    public void SetSuitPriority(Suit firstSuit, Suit secondSuit, Suit thirdSuit, Suit fourthSuit, Suit fifthSuit)
    {
        _suitPriority = new List<Suit>() { firstSuit, secondSuit, thirdSuit, fourthSuit, fifthSuit };
    }
}
