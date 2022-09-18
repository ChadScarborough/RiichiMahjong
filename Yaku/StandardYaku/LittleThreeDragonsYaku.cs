using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.StandardYaku;

public sealed class LittleThreeDragonsYaku : YakuBase
{
    private new readonly StandardCompleteHand _completeHand;

    public LittleThreeDragonsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Little Three Dragons";
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

        int tripletCounter = 0;
        int pairCounter = 0;
        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (component.GetLeadTile().GetSuit() is DRAGON)
            {
                if (component.GetGeneralComponentType() is PAIR)
                {
                    pairCounter++;
                }

                if (component.GetGeneralComponentType() is GROUP)
                {
                    tripletCounter++;
                }
            }
        }

        return tripletCounter == 2 && pairCounter == 1;
    }
}