using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMU.Hands.TenpaiHands
{
    public class StandardTenpaiHandOpenWait : StandardTenpaiHand
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
}