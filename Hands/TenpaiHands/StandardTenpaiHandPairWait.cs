using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
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
                    _waits = new List<TileObject>
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
}
