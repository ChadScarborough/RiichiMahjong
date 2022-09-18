using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public sealed class StandardTenpaiHandClosedWait : StandardTenpaiHand
{
    public StandardTenpaiHandClosedWait(List<ICompleteHandComponent> components) : base(components)
    {
        GenerateWaits();
    }

    private void GenerateWaits()
    {
        foreach (ICompleteHandComponent component in GetComponents())
        {
            if (component.GetComponentType() == INCOMPLETE_SEQUENCE_CLOSED_WAIT)
            {
                _waits = new List<Tile>
                {
                    GetTileAbove(component.GetLeadTile())
                };
                return;
            }
        }
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return CLOSED_WAIT;
    }
}