using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Hands;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class AllTerminalsAndHonors : AbstractYaku
    {
        private int _terminalCounter;
        private int _honorCounter;
        private List<TileObject> _handTiles;

        public AllTerminalsAndHonors()
        {
            _name = "All Terminals and Honors";
            _value = 2;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(Hand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForTerminalsAndHonors(hand, extraTile);
            return AllTilesAreTerminalsOrHonorsAndThereIsAtLeastOneTerminalAndOneHonor();
        }

        private void InitializeValues(Hand hand, TileObject extraTile)
        {
            ResetCounters();
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool AllTilesAreTerminalsOrHonorsAndThereIsAtLeastOneTerminalAndOneHonor()
        {
            return AllTilesAreTerminalsOrHonors() && AtLeastOneTerminalAndAtLeastOneHonor();
        }

        private void CheckForTerminalsAndHonors(Hand hand, TileObject extraTile)
        {
            foreach (TileObject tile in _handTiles)
            {
                CheckHonor(tile);
                CheckTerminal(tile);
            }
        }

        private void ResetCounters()
        {
            _terminalCounter = 0;
            _honorCounter = 0;
        }

        private void CheckTerminal(TileObject tile)
        {
            if (tile.IsTerminal())
            {
                _terminalCounter++;
            }
        }

        private void CheckHonor(TileObject tile)
        {
            if (tile.IsHonor())
            {
                _honorCounter++;
            }
        }

        private bool AllTilesAreTerminalsOrHonors()
        {
            return _terminalCounter + _honorCounter == ConstValues.NUMBER_OF_TILES_IN_FULL_HAND;
        }

        private bool AtLeastOneTerminalAndAtLeastOneHonor()
        {
            return AtLeastOneTerminal() && AtLeastOneHonor();
        }

        private bool AtLeastOneTerminal()
        {
            return _terminalCounter > 0;
        }

        private bool AtLeastOneHonor()
        {
            return _honorCounter > 0;
        }
    }
}
