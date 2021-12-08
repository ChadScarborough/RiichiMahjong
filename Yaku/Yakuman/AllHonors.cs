using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class AllHonors : AbstractYakuman
    {
        private List<TileObject> tileList;

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
            foreach (TileObject tile in tileList)
            {
                if (tile.IsHonor() == false)
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
