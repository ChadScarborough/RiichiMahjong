using RMU.Hands.CompleteHands;

namespace RMU.Yaku.Yakuman;

public sealed class FourConcealedTripletsSingleWaitYakuman : YakumanBase
{
    private new readonly StandardCompleteHand _completeHand;

    public FourConcealedTripletsSingleWaitYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Four Concealed Triplets Single Wait";
        _value = 26;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null)
        {
            return false;
        }

        if (_completeHand.IsOpen())
        {
            return false;
        }

        if (_completeHand.GetTriplets().Count < 4)
        {
            return false;
        }

        return _completeHand.GetWaitType() is PAIR_WAIT;
    }
}
