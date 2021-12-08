using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku
{
    public class AllSimples : AbstractYaku
    {
        private List<TileObject> handTiles;

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
            foreach (TileObject tile in handTiles)
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
            handTiles = hand.GetAllTiles(extraTile);
        }

        private static bool TileIsTerminalOrHonor(TileObject tile)
        {
            return TileIsHonor(tile) || TileIsTerminal(tile);
        }

        private static bool TileIsTerminal(TileObject tile)
        {
            return tile.IsTerminal();
        }

        private static bool TileIsHonor(TileObject tile)
        {
            return tile.IsHonor();
        }
    }
}
