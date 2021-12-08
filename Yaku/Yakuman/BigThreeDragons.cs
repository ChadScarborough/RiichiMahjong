using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class BigThreeDragons : AbstractYakuman
    {
        private int _greenDragonCounter = 0;
        private int _redDragonCounter = 0;
        private int _whiteDragonCounter = 0;
        private List<TileObject> tileList;

        public BigThreeDragons()
        {
            _name = "Big Three Dragons";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckTileListForDragons();
            return AreAtLeastThreeOfEachDragon();
        }

        private void CheckTileListForDragons()
        {
            foreach (TileObject tile in tileList)
            {
                CheckIfTileIsDragonAndIncrementAppropriateCounter(tile);
            }
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            ResetCounters();
            tileList = hand.Listify(extraTile);
        }

        private bool AreAtLeastThreeOfEachDragon()
        {
            return AreAtLeastThreeGreenDragons() && AreAtLeastThreeRedDragons() && AreAtLeastThreeWhiteDragons();
        }

        private bool AreAtLeastThreeGreenDragons()
        {
            return _greenDragonCounter >= 3;
        }

        private bool AreAtLeastThreeRedDragons()
        {
            return _redDragonCounter >= 3;
        }

        private bool AreAtLeastThreeWhiteDragons()
        {
            return _whiteDragonCounter >= 3;
        }

        private void CheckIfTileIsDragonAndIncrementAppropriateCounter(TileObject tile)
        {
            if (IncrementedGreenDragonCounterBecauseTileIsGreenDragon(tile)) return;
            if (IncrementedRedDragonCounterBecauseTileIsRedDragon(tile)) return;
            IncrementWhiteDragonCounterIfTileIsWhiteDragon(tile);
        }

        private bool IncrementedGreenDragonCounterBecauseTileIsGreenDragon(TileObject tile)
        {
            if (TileIsGreenDragon(tile))
            {
                IncrementGreenDragonCounter();
                return true;
            }
            return false;
        }

        private void IncrementGreenDragonCounter()
        {
            _greenDragonCounter++;
        }

        private bool IncrementedRedDragonCounterBecauseTileIsRedDragon(TileObject tile)
        {
            if (TileIsRedDragon(tile))
            {
                IncrementRedDragonCounter();
                return true;
            }
            return false;
        }

        private void IncrementRedDragonCounter()
        {
            _redDragonCounter++;
        }

        private void IncrementWhiteDragonCounterIfTileIsWhiteDragon(TileObject tile)
        {
            if (TileIsWhiteDragon(tile))
            {
                IncrementWhiteDragonCounter();
            }
        }

        private void IncrementWhiteDragonCounter()
        {
            _whiteDragonCounter++;
        }

        private bool TileIsGreenDragon(TileObject tile)
        {
            return TileIsGivenDragon(tile, Enums.GREEN);
        }

        private bool TileIsRedDragon(TileObject tile)
        {
            return TileIsGivenDragon(tile, Enums.RED);
        }

        private bool TileIsWhiteDragon(TileObject tile)
        {
            return TileIsGivenDragon(tile, Enums.WHITE);
        }

        private bool TileIsGivenDragon(TileObject tile, Enums.Dragon dragon)
        {
            return Functions.AreDragonsEquivalent(tile, dragon);
        }

        private void ResetCounters()
        {
            _greenDragonCounter = 0;
            _redDragonCounter = 0;
            _whiteDragonCounter = 0;
        }
    }
}
