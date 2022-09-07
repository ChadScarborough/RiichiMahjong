using RMU.Hands.CompleteHands;
using static RMU.Globals.StandardTileList;

namespace RMU.Yaku.StandardYaku;

public class WhiteDragonYaku : YakuBase
{
    public WhiteDragonYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _value = 1;
        _name = "White Dragon";
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return new YakuhaiYaku(_completeHand, WHITE_DRAGON).Check();
    }
}