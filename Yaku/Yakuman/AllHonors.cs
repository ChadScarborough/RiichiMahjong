using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class AllHonors : AbstractYakuman
    {
        private List<TileObject> handTiles;

        public AllHonors()
        {
            _name = "All Honors";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeTileList(hand, extraTile);
            return HandContainsOnlyHonorTiles();
        }

        private bool HandContainsOnlyHonorTiles()
        {
            foreach (TileObject tile in handTiles)
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

        private void InitializeTileList(IHand hand, TileObject extraTile)
        {
            handTiles = hand.GetAllTiles(extraTile);
        }
    }
}
