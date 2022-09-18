using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public class StandardTenpaiHandPairWait : StandardTenpaiHand
{
    public StandardTenpaiHandPairWait(List<ICompleteHandComponent> components) : base(components)
    {
        GenerateWaits();
    }

    private void GenerateWaits()
    {
        foreach (ICompleteHandComponent component in GetComponents())
        {
            if (component.GetComponentType() == ISOLATED_TILE)
            {
                _waits = new List<Tile>
                {
                    component.GetLeadTile().Clone()
                };
                return;
            }
        }
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return PAIR_WAIT;
    }
}
