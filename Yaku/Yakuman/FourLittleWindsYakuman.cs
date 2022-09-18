using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Yaku.Yakuman;

public sealed class FourLittleWindsYakuman : Yakuman
{
    public FourLittleWindsYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Four Little Winds";
        _value = 13;
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
        int isolatedTileCounter = 0;

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

            if (component.GetComponentType() is ISOLATED_TILE)
            {
                if (component.GetLeadTile().GetSuit() is WIND)
                {
                    isolatedTileCounter++;
                    continue;
                }
            }

            if (component.GetComponentType() is DRAW_TILE)
            {
                if (component.GetLeadTile().GetSuit() is WIND)
                {
                    if (isolatedTileCounter > 0)
                    {
                        isolatedTileCounter--;
                        pairCounter++;
                        continue;
                    }

                    if (pairCounter > 0)
                    {
                        pairCounter--;
                        tripletCounter++;
                    }
                }
            }
        }

        return tripletCounter is 3 && pairCounter is 1;
    }
}