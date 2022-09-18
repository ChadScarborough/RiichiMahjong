using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class GreenDragonYaku : YakuBase
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