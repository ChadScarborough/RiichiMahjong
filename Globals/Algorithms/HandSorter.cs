using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Algorithms
{
    public class HandSorter
    {
        private List<Enums.Suit> _suitPriority;
        private ISortingAlgorithm _sortingAlgorithm;

        public HandSorter()
        {
            this._suitPriority = new List<Enums.Suit>() { Enums.Suit.Man, Enums.Suit.Pin, Enums.Suit.Sou, Enums.Suit.Wind, Enums.Suit.Dragon };
            this._sortingAlgorithm = new RadixSort();
        }
        public List<TileObject> SortHand(List<TileObject> list)
        {
            if(list.Count > 1)
            {
                _sortingAlgorithm.SortHand(list, _suitPriority);
            }
            return list;
        }

        public void SetSuitPriority(Enums.Suit _firstSuit, Enums.Suit _secondSuit, Enums.Suit _thirdSuit, Enums.Suit _fourthSuit, Enums.Suit _fifthSuit)
        {
            this._suitPriority = new List<Enums.Suit>() { _firstSuit, _secondSuit, _thirdSuit, _fourthSuit, _fifthSuit };
        }
    }
}
