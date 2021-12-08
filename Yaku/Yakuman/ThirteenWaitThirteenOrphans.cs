using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;
using RMU.Tiles;
using RMU.Hand;
using RMU.Yaku.YakuLists;

namespace RMU.Yaku.Yakuman
{
    public class ThirteenWaitThirteenOrphans : AbstractYakuman
    {
        private TileObject[] _terminals = new TileObject[]
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

        private int[] _counters = new int[ConstValues.NUMBER_OF_UNIQUE_TERMINALS];
        private int _multiplier = 1;
        private List<TileObject> tileList;

        public ThirteenWaitThirteenOrphans()
        {
            _name = "Thirteen Wait Thirteen Orphans";
            _value = 26;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand);
            CheckForTerminalsInClosedTiles();
            return ClosedTilesContainOneOfEachTerminalAndFullHandIsValidThirteenOrphans(hand, extraTile);
        }

        private void CheckForTerminalsInClosedTiles()
        {
            CheckListForTerminals(tileList);
            MultiplyAllCountersTogether();
        }

        private bool ClosedTilesContainOneOfEachTerminalAndFullHandIsValidThirteenOrphans(IHand hand, TileObject extraTile)
        {
            return OneOfEachTerminal() && IsThirteenOrphans(hand, extraTile);
        }

        private bool OneOfEachTerminal()
        {
            return _multiplier == 1; //If any terminal is missing from the closed tiles, the value of _multiplier will be 0
        }

        private void InitializeValues(IHand hand)
        {
            ClearCounters();
            tileList = hand.GetClosedTiles();
        }

        private void CheckListForTerminals(List<TileObject> tileList)
        {
            foreach (TileObject tile in tileList)
            {
                CheckIfTileIsTerminal(tile);
            }
        }

        private static bool IsThirteenOrphans(IHand hand, TileObject extraTile)
        {
            AbstractYakuman thirteenOrphans = YakumanList.THIRTEEN_ORPHANS;
            return thirteenOrphans.CheckYaku(hand, extraTile);
        }

        private void MultiplyAllCountersTogether()
        {
            foreach (int i in _counters)
            {
                _multiplier *= i;
            }
        }

        private void CheckIfTileIsTerminal(TileObject tile)
        {
            for (int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS; i++)
            {
                if (IncrementedAppropriateCounterBecauseTileIsTerminal(tile, i)) break;
            }
        }

        private bool IncrementedAppropriateCounterBecauseTileIsTerminal(TileObject tile, int i)
        {
            if (TileMatchesGivenTerminal(tile, i))
            {
                IncrementAppropriateCounter(i);
                return true;
            }
            return false;
        }

        private bool TileMatchesGivenTerminal(TileObject tile, int i)
        {
            return Functions.AreTilesEquivalent(tile, _terminals[i]);
        }

        private void IncrementAppropriateCounter(int i)
        {
            _counters[i]++;
        }

        private void ClearCounters()
        {
            for (int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS; i++)
            {
                _counters[i] = 0;
            }
            _multiplier = 1;
        }
    }
}
