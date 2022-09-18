using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public sealed class FullyConcealedHandYaku : YakuBase
{
    public FullyConcealedHandYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Fully Concealed Hand";
        _value = 1;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetPlayer().IsActivePlayer() == false)
        {
            return false;
        }

        return _completeHand.IsOpen() != true;
    }
}
