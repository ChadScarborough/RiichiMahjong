using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class AllTerminalsYakuman : YakumanBase
{
    public AllTerminalsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Terminals";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetComponentType() is OPEN_CHII or CLOSED_CHII)
            {
                return false;
            }

            if (component.GetLeadTile().IsTerminal() is false)
            {
                return false;
            }
        }

        return true;
    }
}