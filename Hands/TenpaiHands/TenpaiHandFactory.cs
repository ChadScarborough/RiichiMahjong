using System;
using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public static class TenpaiHandFactory
    {
        //TODO: Add Thirteen orphans to logic
        
        public static ITenpaiHand CreateTenpaiHand(List<ICompleteHandComponent> components)
        {
            return CreateSevenPairsHand(components);
        }

        private static ITenpaiHand CreateSevenPairsHand(List<ICompleteHandComponent> components)
        {
            if (components.Count > 6)
            {
                int p = 0;
                foreach (ICompleteHandComponent component in components)
                {
                    if (component.GetComponentType() == PAIR_COMPONENT)
                    {
                        p++;
                    }
                }

                if (p == 6)
                {
                    return new SevenPairsTenpaiHand(components);
                }
            }
            return CreatePairWaitHand(components);
        }

        private static ITenpaiHand CreatePairWaitHand(List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == ISOLATED_TILE)
                {
                    return new StandardTenpaiHandPairWait(components);
                }
            }

            return CreateTwoSidedTripletWaitHand(components);
        }

        private static ITenpaiHand CreateTwoSidedTripletWaitHand(List<ICompleteHandComponent> components)
        {
            int p = 0;
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == PAIR_COMPONENT)
                {
                    p++;
                }
            }

            if (p == 2)
            {
                return new StandardTenpaiHandTwoSidedTripletWait(components);
            }

            return CreateClosedWaitHand(components);
        }

        private static ITenpaiHand CreateClosedWaitHand(List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_CLOSED_WAIT)
                {
                    return new StandardTenpaiHandClosedWait(components);
                }
            }

            return CreateEdgeWaitHand(components);
        }

        private static ITenpaiHand CreateEdgeWaitHand(List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_EDGE_WAIT)
                {
                    return new StandardTenpaiHandEdgeWait(components);
                }
            }

            return CreateOpenWaitHand(components);
        }

        private static ITenpaiHand CreateOpenWaitHand(List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_OPEN_WAIT)
                {
                    return new StandardTenpaiHandOpenWait(components);
                }
            }

            throw new Exception("Hand does not form valid tenpai hand");
        }
    }
}