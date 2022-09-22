using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku;

public sealed class ThreeQuadsYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public ThreeQuadsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Three Quads";
        _value = 2;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand?.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        int quadCounter = 0;

        foreach (ICompleteHandComponent component in _completeHand.GetTriplets())
        {
            if (component.GetComponentType() is OPEN_KAN or CLOSED_KAN_COMPONENT)
            {
                quadCounter++;
            }
        }

        return quadCounter == 3;
    }
}