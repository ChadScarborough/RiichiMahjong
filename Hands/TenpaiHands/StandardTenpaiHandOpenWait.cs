using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public sealed class StandardTenpaiHandOpenWait : StandardTenpaiHand
{
    public StandardTenpaiHandOpenWait(List<ICompleteHandComponent> components) : base(components)
    {
        GenerateWaits();
    }

    private void GenerateWaits()
    {
        foreach (ICompleteHandComponent component in GetComponents())
        {
            if (component.GetComponentType() == INCOMPLETE_SEQUENCE_OPEN_WAIT)
            {
                Tile tile = component.GetLeadTile();
                _waits = new List<Tile>
                {
                    GetTileBelow(tile),
                    GetTileTwoAbove(tile)
                };
                return;
            }
        }
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return OPEN_WAIT;
    }
}