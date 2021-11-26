using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku
{
    public abstract class Yaku
    {
        protected const int NUMBER_OF_TILES_IN_FULL_HAND = 14;
        private string _name;
        private int _value;

        public abstract bool CheckYaku(IHand hand, TileObject extraTile);
        public abstract string GetName();

        public abstract int GetValue();
    }
}
