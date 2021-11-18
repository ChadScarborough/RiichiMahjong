using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Algorithms
{
    public class HandSorter
    {
        private TileEnums.Suit _firstSuit;
        private TileEnums.Suit _secondSuit;
        private TileEnums.Suit _thirdSuit;
        private TileEnums.Suit _fourthSuit;
        private TileEnums.Suit _fifthSuit;
        private List<TileEnums.Suit> _suitPriority;
        private ISortingAlgorithm _sortingAlgorithm;

        public HandSorter()
        {
            this._firstSuit = TileEnums.Suit.Man;
            this._secondSuit = TileEnums.Suit.Pin;
            this._thirdSuit = TileEnums.Suit.Sou;
            this._fourthSuit = TileEnums.Suit.Wind;
            this._fifthSuit = TileEnums.Suit.Dragon;
            this._suitPriority = new List<TileEnums.Suit>() { _firstSuit, _secondSuit, _thirdSuit, _fourthSuit, _fifthSuit };
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
            this._firstSuit = _firstSuit;
            this._secondSuit = _secondSuit;
            this._thirdSuit = _thirdSuit;
            this._fourthSuit = _fourthSuit;
            this._fifthSuit = _fifthSuit;
            this._suitPriority = new List<TileEnums.Suit>() { _firstSuit, _secondSuit, _thirdSuit, _fourthSuit, _fifthSuit };
        }
    }
}
