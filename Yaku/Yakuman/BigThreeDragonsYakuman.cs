using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class BigThreeDragonsYakuman : YakumanBase
{
    public BigThreeDragonsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _value = 13;
        _name = "Big Three Dragons";
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }
        int tripletCounter = 0;
        int pairCounter = 0;

        foreach (ICompleteHandComponent component in _completeHand.GetComponents())
        {
            if (component.GetComponentType() is OPEN_PON or CLOSED_PON or OPEN_KAN or CLOSED_KAN_COMPONENT)
            {
                if (component.GetLeadTile().GetSuit() is DRAGON)
                {
                    tripletCounter++;
                    continue;
                }
            }

            if (component.GetComponentType() is PAIR_COMPONENT)
            {
                if (component.GetLeadTile().GetSuit() is DRAGON)
                {
                    pairCounter++;
                    continue;
                }
            }

            if (component.GetComponentType() is not DRAW_TILE) continue;
            if (component.GetLeadTile().GetSuit() is not DRAGON) continue;
            pairCounter--;
            tripletCounter++;
        }

        return tripletCounter is 3 && pairCounter is 0;
    }
}