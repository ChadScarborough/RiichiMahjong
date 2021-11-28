using RMU.Hand;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku
{
    public class FullFlush : AbstractYaku
    {
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
            return false;
        }
    }
}
