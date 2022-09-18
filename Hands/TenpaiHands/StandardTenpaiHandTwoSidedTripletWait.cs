using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public class StandardTenpaiHandTwoSidedTripletWait : StandardTenpaiHand
{
    public StandardTenpaiHandTwoSidedTripletWait(List<ICompleteHandComponent> components) : base(components)
    {
        GenerateWaits();
    }

    private void GenerateWaits()
    {
        int p = 0;
        List<Tile> w = new();

        foreach (ICompleteHandComponent component in GetComponents())
        {
            if (component.GetComponentType() == PAIR_COMPONENT)
            {
                p++;
                w.Add(component.GetLeadTile().Clone());
                if (p == 2)
                {
                    _waits = w;
                    return;
                }
            }
        }
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return TWO_SIDED_TRIPLET_WAIT;
    }
}