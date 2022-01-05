using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Hands;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku.Yakuman
{
    public class FourLittleWinds : AbstractYakuman
    {
        int _eastWindCounter;
        int _southWindCounter;
        int _westWindCounter;
        int _northWindCounter;
        List<TileObject> _handTiles;

        public FourLittleWinds()
        {
            _name = "Four Little Winds";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(Hand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckHandForWindTilesAndIncrementAppropriateCounters();
            return AreExactlyTwoOfOneWindAndAtLeastThreeEachOfTheOthers();
        }

        private bool AreExactlyTwoOfOneWindAndAtLeastThreeEachOfTheOthers()
        {
            if (ExactlyTwoEastWindsAndAtLeastThreeEachOfTheOthers()) return true;
            if (ExactlyTwoSouthWindsAndAtLeastThreeEachOfTheOthers()) return true;
            if (ExactlyTwoWestWindsAndAtLeastThreeEachOfTheOthers()) return true;
            if (ExactlyTwoNorthWindsAndAtLeastThreeEachOfTheOthers()) return true;
            return false;
        }

        private bool ExactlyTwoNorthWindsAndAtLeastThreeEachOfTheOthers()
        {
            return _eastWindCounter >= 3 && _southWindCounter >= 3 && _westWindCounter >= 3 && _northWindCounter == 2;
        }

        private bool ExactlyTwoWestWindsAndAtLeastThreeEachOfTheOthers()
        {
            return _eastWindCounter >= 3 && _southWindCounter >= 3 && _westWindCounter == 2 && _northWindCounter >= 3;
        }

        private bool ExactlyTwoSouthWindsAndAtLeastThreeEachOfTheOthers()
        {
            return _eastWindCounter >= 3 && _southWindCounter == 2 && _westWindCounter >= 3 && _northWindCounter >= 3;
        }

        private bool ExactlyTwoEastWindsAndAtLeastThreeEachOfTheOthers()
        {
            return _eastWindCounter == 2 && _southWindCounter >= 3 && _westWindCounter >= 3 && _northWindCounter >= 3;
        }

        private void CheckHandForWindTilesAndIncrementAppropriateCounters()
        {
            foreach(TileObject tile in _handTiles)
            {
                if(Functions.AreWindsEquivalent(tile, Enums.EAST)) 
                { 
                    _eastWindCounter++;
                    continue;
                }
                if(Functions.AreWindsEquivalent(tile, Enums.SOUTH))
                {
                    _southWindCounter++;
                    continue;
                }
                if(Functions.AreWindsEquivalent(tile, Enums.WEST))
                {
                    _westWindCounter++;
                    continue;
                }
                if(Functions.AreWindsEquivalent(tile, Enums.NORTH))
                {
                    _northWindCounter++;
                    continue;
                }
            }
        }

        private void InitializeValues(Hand hand, TileObject extraTile)
        {
            ResetCounters();
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private void ResetCounters()
        {
            _eastWindCounter = 0;
            _southWindCounter = 0;
            _westWindCounter = 0;
            _northWindCounter = 0;
        }
    }
}
