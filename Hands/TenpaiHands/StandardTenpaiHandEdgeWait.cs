using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Tiles.TileFactory;

namespace RMU.Hands.TenpaiHands
{
    public class StandardTenpaiHandEdgeWait : StandardTenpaiHand
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
                    TileObject tile = component.GetLeadTile();
                    if (tile.GetValue() == 1)
                    {
                        _waits = new List<TileObject>
                        {
                            CreateTile(3, tile.GetSuit())
                        };
                        return;
                    }

                    _waits = new List<TileObject>
                    {
                        CreateTile(8, tile.GetSuit())
                    };
                }
            }
        }
    }
}