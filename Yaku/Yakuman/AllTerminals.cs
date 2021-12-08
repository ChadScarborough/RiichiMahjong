using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class AllTerminals : AbstractYakuman
    {
        private List<TileObject> tileList;

        public AllTerminals()
        {
            _name = "All Terminals";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeTileList(hand, extraTile);
            return HandContainsOnlyTerminalTiles();
        }

        private bool HandContainsOnlyTerminalTiles()
        {
            foreach (TileObject tile in tileList)
            {
                if (tile.IsTerminal() == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void InitializeTileList(IHand hand, TileObject extraTile)
        {
            tileList = hand.Listify(extraTile);
        }
    }
}
