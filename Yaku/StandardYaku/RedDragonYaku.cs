using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class RedDragonYaku : YakuBase
{
    public RedDragonYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _value = 1;
        _name = "Red Dragon";
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return new YakuhaiYaku(_completeHand, RED_DRAGON).Check();
    }
}