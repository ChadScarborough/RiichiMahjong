using RMU.Tiles;
using System.Collections.Generic;
using RMU.Hands;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class AllSimples : AbstractYaku
    {
        private List<TileObject> _handTiles;

        public AllSimples()
        {
            _name = "All Simples";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(Hand hand, TileObject extraTile)
        {
            InitializeTileList(hand, extraTile);
            return HandContainsNoTerminalsOrHonors();
        }

        private bool HandContainsNoTerminalsOrHonors()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsTerminalOrHonor(tile))
                {
                    return false;
                }
            }
            return true;
        }

        private void InitializeTileList(Hand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
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
