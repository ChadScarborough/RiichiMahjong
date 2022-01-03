using RMU.Yaku.StrategyBehaviours;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku
{
    public class LittleThreeDragons : AbstractYaku
    {
        private int _greenDragonCounter;
        private int _redDragonCounter;
        private int _whiteDragonCounter;
        private List<TileObject> _handTiles;

        public LittleThreeDragons()
        {
            _name = "Little Three Dragons";
            _value = 2;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckHandForDragonTilesAndIncrementCounters();
            return HandContainsExactlyTwoOfOneDragonTileAndAtLeastThreeEachOfTheOtherTwo();
        }

        private bool HandContainsExactlyTwoOfOneDragonTileAndAtLeastThreeEachOfTheOtherTwo()
        {
            if (TwoGreenDragonsAndAtLeastThreeEachOfTheOtherTwo()) return true;
            if (TwoRedDragonsAndAtLeastThreeEachOfTheOtherTwo()) return true;
            if (TwoWhiteDragonsAndAtLeastThreeEachOfTheOtherTwo()) return true;
            return false;
        }

        private bool TwoWhiteDragonsAndAtLeastThreeEachOfTheOtherTwo()
        {
            return _greenDragonCounter >= 3 && _redDragonCounter >= 3 && _whiteDragonCounter == 2;
        }

        private bool TwoRedDragonsAndAtLeastThreeEachOfTheOtherTwo()
        {
            return _greenDragonCounter >= 3 && _redDragonCounter == 2 && _whiteDragonCounter >= 3;
        }

        private bool TwoGreenDragonsAndAtLeastThreeEachOfTheOtherTwo()
        {
            return _greenDragonCounter == 2 && _redDragonCounter >= 3 && _whiteDragonCounter >= 3;
        }

        private void CheckHandForDragonTilesAndIncrementCounters()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsGreenDragonTile(tile))
                {
                    _greenDragonCounter++;
                    continue;
                }
                if (TileIsRedDragonTile(tile))
                {
                    _redDragonCounter++;
                    continue;
                }
                if (TileIsWhiteDragonTile(tile))
                {
                    _whiteDragonCounter++;
                }
            }
        }

        private static bool TileIsWhiteDragonTile(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.WHITE);
        }

        private static bool TileIsRedDragonTile(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.RED);
        }

        private static bool TileIsGreenDragonTile(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.GREEN);
        }

        private void InitializeValues(AbstractHand hand, TileObject extraTile)
        {
            ResetCounters();
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private void ResetCounters()
        {
            _greenDragonCounter = 0;
            _redDragonCounter = 0;
            _whiteDragonCounter = 0;
        }
    }
}
