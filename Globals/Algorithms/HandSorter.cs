using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Globals.Algorithms
{
    public class HandSorter
    {
        private List<Enums.Suit> _suitPriority;
        private readonly ISortingAlgorithm _sortingAlgorithm;

        public HandSorter()
        {
            this._suitPriority = new List<Enums.Suit>() { Enums.MAN, Enums.PIN, Enums.SOU, Enums.WIND, Enums.DRAGON };
            this._sortingAlgorithm = new RadixSort();
        }
        public List<Tile> SortHand(List<Tile> list)
        {
            if(list.Count > 1)
            {
                _sortingAlgorithm.SortHand(list, _suitPriority);
            }
            return list;
        }

        public void SetSuitPriority(Enums.Suit firstSuit, Enums.Suit secondSuit, Enums.Suit thirdSuit, Enums.Suit fourthSuit, Enums.Suit fifthSuit)
        {
            this._suitPriority = new List<Enums.Suit>() { firstSuit, secondSuit, thirdSuit, fourthSuit, fifthSuit };
        }
    }
}
