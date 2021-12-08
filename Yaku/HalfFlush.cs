using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Yaku
{
    public class HalfFlush : AbstractYaku
    {
        private Enums.Suit _suit;
        private List<TileObject> _tiles;

        public HalfFlush()
        {
            _name = "Half Flush";
            _value = 3;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            if (HandContainsHonorsAndNonHonors() == false) return false;
            return EveryTileIsSameSuitOrHonor();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            _hand = hand;
            _tiles = hand.Listify(extraTile);
        }

        private bool EveryTileIsSameSuitOrHonor()
        {
            foreach (TileObject tile in _tiles)
            {
                if (tile.GetSuit() == _suit) continue;
                if (tile.IsHonor()) continue;
                return false;
            }
            return true;
        }

        private bool HandContainsHonorsAndNonHonors()
        {
            if (SuccessfullyFoundNonHonorTile() == false) return false;
            if (SuccessfullyFoundHonorTile() == false) return false;
            return true;
        }

        private bool SuccessfullyFoundNonHonorTile()
        {
            foreach (TileObject tile in _tiles)
            {
                if (tile.IsHonor() == false)
                {
                    SetNonHonorSuit(tile);
                    return true;
                }
            }
            return false;
        }

        private void SetNonHonorSuit(TileObject tile)
        {
            _suit = tile.GetSuit();
        }

        private bool SuccessfullyFoundHonorTile()
        {
            foreach(TileObject tile in _tiles)
            {
                if (tile.IsHonor())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
