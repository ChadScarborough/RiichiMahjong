using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Yaku.Yakuman;

public class FourQuadsYakuman : Yakuman
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

        int quadCounter = 0;

        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetComponentType() is OPEN_KAN or CLOSED_KAN_COMPONENT)
            {
                quadCounter++;
            }
        }

        return quadCounter == 4;
    }
}