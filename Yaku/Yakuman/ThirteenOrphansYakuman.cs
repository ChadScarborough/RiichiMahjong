using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public sealed class ThirteenOrphansYakuman : YakumanBase
{
    public ThirteenOrphansYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Thirteen Orphans";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return _completeHand.GetCompleteHandType() is THIRTEEN_ORPHANS && _completeHand.GetWaitType() is SINGLE_WAIT;
    }
}