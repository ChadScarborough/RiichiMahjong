using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class SevenPairsYaku : YakuBase
{
    public SevenPairsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Seven Pairs";
        _value = 2;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return _completeHand.GetCompleteHandType() is SEVEN_PAIRS;
    }
}