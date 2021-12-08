using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class AllTerminals : AbstractYakuman
    {
        private List<TileObject> handTiles;

        public AllTerminals()
        {
            _name = "All Terminals";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeHandTiles(hand, extraTile);
            return HandContainsOnlyTerminalTiles();
        }

        private bool HandContainsOnlyTerminalTiles()
        {
            foreach (TileObject tile in handTiles)
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

        private void InitializeHandTiles(IHand hand, TileObject extraTile)
        {
            handTiles = hand.GetAllTiles(extraTile);
        }
    }
}
