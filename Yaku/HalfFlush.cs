using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

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
            _hand = hand;
            _tiles = hand.Listify(extraTile);
            if (HandContainsHonorsAndNonHonors() == false) return false;
            return EveryTileIsSameSuitOrHonor();
        }

        private bool EveryTileIsSameSuitOrHonor()
        {
            foreach (TileObject tile in _tiles)
            {
                if (tile.GetSuit() == this._suit) continue;
                if (tile.IsHonor()) continue;
                return false;
            }
            return true;
        }

        private bool HandContainsHonorsAndNonHonors()
        {
            if (SuccessfullyFoundNonHonorSuit() == false) return false;
            if (SuccessfullyFoundHonorTile() == false) return false;
            return true;
        }

        private bool SuccessfullyFoundNonHonorSuit()
        {
            foreach (TileObject tile in _tiles)
            {
                if (tile.IsHonor() == false)
                {
                    this._suit = tile.GetSuit();
                    return true;
                }
            }
            return false;
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
