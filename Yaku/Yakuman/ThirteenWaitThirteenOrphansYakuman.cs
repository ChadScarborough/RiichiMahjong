using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public sealed class ThirteenWaitThirteenOrphansYakuman : Yakuman
{
    public ThirteenWaitThirteenOrphansYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Thirteen Wait Thirteen Orphans";
        _value = 26;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        return _completeHand.GetCompleteHandType() is THIRTEEN_ORPHANS && _completeHand.GetWaitType() is THIRTEEN_WAIT;
    }
}