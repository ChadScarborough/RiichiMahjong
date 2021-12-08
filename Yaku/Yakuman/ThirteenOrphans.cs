using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;
using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku.Yakuman
{
    public class ThirteenOrphans : AbstractYakuman
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

        public ThirteenOrphans()
        {
            _name = "Thirteen Orphans";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckHandForTerminals();
            return HandContainsExactlyOneOfEveryTerminalPlusASecondCopyOfOne();
        }

        private bool HandContainsExactlyOneOfEveryTerminalPlusASecondCopyOfOne()
        {
            return _multiplier == 2; //A hand that does not meet the conditions for Thirteen Orphans will have a _multiplier value of 0
        }

        private void CheckHandForTerminals()
        {
            CheckListForTerminals(tileList);
            MultiplyAllCountersTogether();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            ClearCounters();
            tileList = hand.Listify(extraTile);
        }

        private void MultiplyAllCountersTogether()
        {
            foreach (int i in _counters)
            {
                _multiplier *= i;
            }
        }

        private void CheckListForTerminals(List<TileObject> tileList)
        {
            foreach (TileObject tile in tileList)
            {
                CheckIfTileIsTerminal(tile);
            }
        }

        private void CheckIfTileIsTerminal(TileObject tile)
        {
            for (int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS; i++)
            {
                if(IncrementedAppropriateCounterBecauseTileIsTerminal(tile, i)) break;
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
            for(int i = 0; i < ConstValues.NUMBER_OF_UNIQUE_TERMINALS; i++)
            {
                _counters[i] = 0;
            }
            _multiplier = 1;
        }
    }
}
