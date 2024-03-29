using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;
using static RMU.Tiles.TileFactory;

namespace RMU.Hands.TenpaiHands;

public sealed class StandardTenpaiHandEdgeWait : StandardTenpaiHand
{
    public StandardTenpaiHandEdgeWait(List<ICompleteHandComponent> components) : base(components)
    {
        GenerateWaits();
    }

    private void GenerateWaits()
    {
        foreach (ICompleteHandComponent component in GetComponents())
        {
            if (component.GetComponentType() == INCOMPLETE_SEQUENCE_EDGE_WAIT)
            {
                Tile tile = component.GetLeadTile();
                if (tile.GetValue() == 1)
                {
                    _waits = new List<Tile>
                    {
                        CreateTile(3, tile.GetSuit())
                    };
                    return;
                }

                _waits = new List<Tile>
                {
                    CreateTile(8, tile.GetSuit())
                };
            }
        }
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return EDGE_WAIT;
    }
}