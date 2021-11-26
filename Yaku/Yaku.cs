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
        protected string _name;
        protected int _value;
        protected IGetNameBehaviour _getNameBehaviour;
        protected IGetValueBehaviour _getValueBehaviour;

        public abstract bool CheckYaku(IHand hand, TileObject extraTile);
        public string GetName()
        {
            return _getNameBehaviour.GetName(_name);
        }

        public int GetValue()
        {
            return _getValueBehaviour.GetValue(_value);
        }
    }
}
