using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public class StandardTenpaiHandTwoSidedTripletWait : StandardTenpaiHand
    {
        public StandardTenpaiHandTwoSidedTripletWait(List<ICompleteHandComponent> components) : base(components)
        {
            GenerateWaits();
        }

        private void GenerateWaits()
        {
            int p = 0;
            List<TileObject> w = new List<TileObject>();

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
    }
}