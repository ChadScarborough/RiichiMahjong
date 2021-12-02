﻿using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Yaku
{
    public class FullFlush : AbstractYaku
    {
        private Enums.Suit _suit;
        private List<TileObject> _tiles;

        public FullFlush()
        {
            _name = "Full Flush";
            _value = 6;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            _hand = hand;
            _tiles = hand.Listify(extraTile);
            if (SuccessfullyFoundNonHonorSuit() == false) return false;
            foreach(TileObject tile in _tiles)
            {
                if (tile.GetSuit() == this._suit) continue;
                return false;
            }
            return true;
        }

        private bool SuccessfullyFoundNonHonorSuit()
        {
            foreach(TileObject tile in _tiles)
            {
                if(tile.IsHonor() == false)
                {
                    this._suit = tile.GetSuit();
                    return true;
                }
            }
            return false;
        }
    }
}
