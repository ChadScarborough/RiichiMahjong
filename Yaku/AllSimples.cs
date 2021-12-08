using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku
{
    public class AllSimples : AbstractYaku
    {
        private List<TileObject> tiles;

        public AllSimples()
        {
            _name = "All Simples";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeTileList(hand, extraTile);
            return HandContainsNoTerminalsOrHonors();
        }

        private bool HandContainsNoTerminalsOrHonors()
        {
            foreach (TileObject tile in tiles)
            {
                if (TileIsTerminalOrHonor(tile))
                {
                    return false;
                }
            }
            return true;
        }

        private void InitializeTileList(IHand hand, TileObject extraTile)
        {
            tiles = hand.GetAllTiles(extraTile);
        }

        private static bool TileIsTerminalOrHonor(TileObject tile)
        {
            return tile.IsHonor() || tile.IsTerminal();
        }
    }
}
