using RMU.Hand;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku
{
    public class AllSimples : Yaku
    {
        private readonly string _name;
        private readonly int _value;
        private IGetNameBehaviour getNameBehaviour;
        private IGetValueBehaviour getValueBehaviour;

        public AllSimples()
        {
            _name = "All Simples";
            _value = 1;
            getNameBehaviour = new StandardGetNameBehaviour();
            getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                if (tile.IsHonor() || tile.IsTerminal())
                {
                    return false;
                }
            }
            return true;
        }

        public override string GetName()
        {
            return getNameBehaviour.GetName(_name);
        }

        public override int GetValue()
        {
            return getValueBehaviour.GetValue(_value);
        }
    }
}
