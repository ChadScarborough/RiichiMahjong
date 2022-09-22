using System.Linq;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class FourQuadsYakuman : YakumanBase
{
    public FourQuadsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Four Quads";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        int quadCounter = _completeHand.GetComponents().Count(
            component => component.GetComponentType() is OPEN_KAN or CLOSED_KAN_COMPONENT);

        return quadCounter == 4;
    }
}