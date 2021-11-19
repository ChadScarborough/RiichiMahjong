using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Algorithms
{
    public class HandSorter
    {
        private List<TileEnums.Suit> _suitPriority;
        private ISortingAlgorithm _sortingAlgorithm;

        public HandSorter()
        {
            this._suitPriority = new List<TileEnums.Suit>() { TileEnums.Suit.Man, TileEnums.Suit.Pin, TileEnums.Suit.Sou, TileEnums.Suit.Wind, TileEnums.Suit.Dragon };
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

        public void SetSuitPriority(TileEnums.Suit _firstSuit, TileEnums.Suit _secondSuit, TileEnums.Suit _thirdSuit, TileEnums.Suit _fourthSuit, TileEnums.Suit _fifthSuit)
        {
            this._suitPriority = new List<TileEnums.Suit>() { _firstSuit, _secondSuit, _thirdSuit, _fourthSuit, _fifthSuit };
        }
    }
}
