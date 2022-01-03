using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku.Yakuman
{
    public class AllHonors : AbstractYakuman
    {
        private List<TileObject> _handTiles;

        public AllHonors()
        {
            _name = "All Honors";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeTileList(hand, extraTile);
            return HandContainsOnlyHonorTiles();
        }

        private bool HandContainsOnlyHonorTiles()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsNotHonor(tile))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool TileIsNotHonor(TileObject tile)
        {
            return tile.IsHonor() == false;
        }

        private void InitializeTileList(AbstractHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
        }
    }
}
