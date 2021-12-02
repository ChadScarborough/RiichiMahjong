using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class AllTerminalsAndHonors : AbstractYaku
    {
        private int _terminalCounter;
        private int _honorCounter;

        public AllTerminalsAndHonors()
        {
            _name = "All Terminals and Honors";
            _value = 2;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            ResetCounters();
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                CheckHonor(tile);
                CheckTerminal(tile);
            }
            return (AllTilesAreTerminalsOrHonors() && AtLeastOneTerminalAndAtLeastOneHonor());
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
            return _terminalCounter + _honorCounter >= ConstValues.NUMBER_OF_TILES_IN_FULL_HAND;
        }

        private bool AtLeastOneTerminalAndAtLeastOneHonor()
        {
            return _terminalCounter * _honorCounter != 0;
        }
    }
}
