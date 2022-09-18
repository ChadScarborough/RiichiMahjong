using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class AllTripletsYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public AllTripletsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Triplets";
        _value = 2;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null)
        {
            return false;
        }

        return _completeHand.GetCompleteHandType() is STANDARD && _completeHand.GetTriplets().Count == 4;
    }
}