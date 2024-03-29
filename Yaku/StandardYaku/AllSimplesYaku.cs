using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku;

public sealed class AllSimplesYaku : YakuBase
{
    public AllSimplesYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Simples";
        _value = 1;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetComponentType() is OPEN_CHII or CLOSED_CHII)
            {
                if (component.GetLeadTile().GetValue() is not 1 and not 7) //A sequence starting with 1 or 7 necessarily contains a terminal
                {
                    continue;
                }

                return false;
            }

            if (component.GetLeadTile().IsTerminalOrHonor())
            {
                return false;
            }
        }

        return true;
    }
}