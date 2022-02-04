using RMU.Hands.CompleteHands;
using static RMU.Globals.StandardTileList;

namespace RMU.Yaku.StandardYaku;

public class GreenDragonYaku : Yaku
{
    public GreenDragonYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _value = 1;
        _name = "Green Dragon";
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return new YakuhaiYaku(_completeHand, GREEN_DRAGON).Check();
    }
}