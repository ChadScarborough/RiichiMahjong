using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku.Yakuman
{
    public class ThirteenWaitThirteenOrphans : AbstractYakuman
    {
        private readonly TileObject[] _terminalsAndHonors =
        {
            StandardTileList.ONE_MAN,
            StandardTileList.NINE_MAN,
            StandardTileList.ONE_PIN,
            StandardTileList.NINE_PIN,
            StandardTileList.ONE_SOU,
            StandardTileList.NINE_SOU,
            StandardTileList.EAST_WIND,
            StandardTileList.SOUTH_WIND,
            StandardTileList.WEST_WIND,
            StandardTileList.NORTH_WIND,
            StandardTileList.GREEN_DRAGON,
            StandardTileList.RED_DRAGON,
            StandardTileList.WHITE_DRAGON
        };

        private readonly int[] _counters = new int[ConstValues.NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS];
        private int _multiplier = 1;
        private List<TileObject> _handTiles;

        public ThirteenWaitThirteenOrphans()
        {
            _name = "Thirteen Wait Thirteen Orphans";
            _value = 26;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand);
            CheckForHonorsAndTerminalsInClosedTiles();
            return ClosedTilesContainOneOfEachHonorAndTerminal_AndExtraTileIsHonorOrTerminal(extraTile);
        }

        private void CheckForHonorsAndTerminalsInClosedTiles()
        {
            CheckListForHonorsAndTerminals(_handTiles);
            MultiplyAllCountersTogether();
        }

        private bool ClosedTilesContainOneOfEachHonorAndTerminal_AndExtraTileIsHonorOrTerminal(TileObject extraTile)
        {
            return HandContainsOneOfEachHonorAndTerminal() && ExtraTileIsHonorOrTerminal(extraTile);
        }

        private bool ExtraTileIsHonorOrTerminal(TileObject extraTile)
        {
            return ExtraTileIsHonor(extraTile) || ExtraTileIsTerminal(extraTile);
        }

        private bool ExtraTileIsHonor(TileObject extraTile)
        {
            return extraTile.IsHonor();
        }

        private bool ExtraTileIsTerminal(TileObject extraTile)
        {
            return extraTile.IsTerminal();
        }

        private bool HandContainsOneOfEachHonorAndTerminal()
        {
            return _multiplier == 1; 
            //If any terminal is missing from the closed tiles, the value of _multiplier will be 0
        }

        private void InitializeValues(AbstractHand hand)
        {
            ClearCounters();
            _handTiles = hand.GetClosedTiles();
        }

        private void CheckListForHonorsAndTerminals(List<TileObject> tileList)
        {
            foreach (TileObject tile in tileList)
            {
                CheckIfTileIsHonorOrTerminal(tile);
            }
        }

        private void MultiplyAllCountersTogether()
        {
            foreach (int i in _counters)
            {
                _multiplier *= i;
            }
        }

        private void CheckIfTileIsHonorOrTerminal(TileObject tile)
        {
            for (int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; i++)
            {
                if (IncrementedAppropriateCounter_BecauseTileIsHonorOrTerminal(tile, i)) break;
            }
        }

        private bool IncrementedAppropriateCounter_BecauseTileIsHonorOrTerminal(TileObject tile, int i)
        {
            if (TileMatchesGivenHonorOrTerminal(tile, i))
            {
                IncrementAppropriateCounter(i);
                return true;
            }
            return false;
        }

        private bool TileMatchesGivenHonorOrTerminal(TileObject tile, int i)
        {
            return Functions.AreTilesEquivalent(tile, _terminalsAndHonors[i]);
        }

        private void IncrementAppropriateCounter(int i)
        {
            _counters[i]++;
        }

        private void ClearCounters()
        {
            for (int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; i++)
            {
                _counters[i] = 0;
            }
            _multiplier = 1;
        }
    }
}
