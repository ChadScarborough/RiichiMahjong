using RMU.Hands.CompleteHands;
using static RMU.Globals.Enums;

namespace RMU.Yaku.StandardYaku;

public class SevenPairsYaku : YakuBase
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