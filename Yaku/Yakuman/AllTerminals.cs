using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku.Yakuman
{
    public class AllTerminals : AbstractYakuman
    {
        private List<TileObject> _handTiles;

        public AllTerminals()
        {
            _name = "All Terminals";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeHandTiles(hand, extraTile);
            return HandContainsOnlyTerminalTiles();
        }

        private bool HandContainsOnlyTerminalTiles()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsNotTerminal(tile))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool TileIsNotTerminal(TileObject tile)
        {
            return tile.IsTerminal() == false;
        }

        private void InitializeHandTiles(AbstractHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
        }
    }
}
