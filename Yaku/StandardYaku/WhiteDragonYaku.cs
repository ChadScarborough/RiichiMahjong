using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class WhiteDragonYaku : YakuBase
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