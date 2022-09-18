using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class FourBigWindsYakuman : Yakuman
{
    public FourBigWindsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Four Big Winds";
        _value = 26;
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
                if (component.GetLeadTile().GetSuit() is WIND)
                {
                    tripletCounter++;
                    continue;
                }
            }

            if (component.GetComponentType() is PAIR_COMPONENT)
            {
                if (component.GetLeadTile().GetSuit() is WIND)
                {
                    pairCounter++;
                    continue;
                }
            }

            if (component.GetComponentType() is DRAW_TILE)
            {
                if (component.GetLeadTile().GetSuit() is WIND)
                {
                    pairCounter--;
                    tripletCounter++;
                }
            }
        }

        return tripletCounter is 4 && pairCounter is 0;
    }
}