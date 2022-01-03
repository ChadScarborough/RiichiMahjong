using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku.Yakuman
{
    public class NineGates : AbstractYakuman
    {
        private List<TileObject> _handTiles;
        private Enums.Suit _suit;
        private int[] _tileCounters;
        private const int ONE = 0;
        private const int NINE = 8;

        public NineGates()
        {
            _name = "Nine Gates";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            if (FirstTileIsHonor()) return false; //Hand should contain no honor tiles, so if the first tile is an honor tile, the hand automatically fails
            SetSuit();
            return HandMeetsSpecificRequirementsForNineGates();
        }

        private bool HandMeetsSpecificRequirementsForNineGates()
        {
            if (AllTilesAreOfTheSameSuit() == false) return false;
            for (int i = ONE; i < ConstValues.NUMBER_OF_UNIQUE_NUMERICAL_VALUES; i++)
            {
                if (i == ONE || i == NINE)
                {
                    if (_tileCounters[i] < 3) return false;
                    continue;
                }
                if (_tileCounters[i] < 1) return false;
            }
            return true;
        }

        private bool AllTilesAreOfTheSameSuit()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (tile.GetSuit() != _suit)
                {
                    return false;
                }
                _tileCounters[tile.GetValue() - 1]++;
            }
            return true;
        }

        private void SetSuit()
        {
            _suit = _handTiles[0].GetSuit();
        }

        private bool FirstTileIsHonor()
        {
            return _handTiles[0].IsHonor();
        }

        private void InitializeValues(AbstractHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
            _tileCounters = new int[ConstValues.NUMBER_OF_UNIQUE_NUMERICAL_VALUES];
        }
    }
}
