using System;
using System.Collections.Generic;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;

namespace RMU.Hands.TenpaiHands
{
    public static class TenpaiHandFactory
    {
        public static ITenpaiHand CreateTenpaiHand(Hand hand, List<ICompleteHandComponent> components)
        {
            hand.ClearWaits();
            return CreateThirteenOrphansHand(hand, components);
        }

        private static ITenpaiHand CreateThirteenOrphansHand(Hand hand, List<ICompleteHandComponent> components)
        {
            if (components.Count >= 12)
            {
                ITenpaiHand outputHand;
                foreach (ICompleteHandComponent component in components)
                {
                    if (component.GetComponentType() == PAIR_COMPONENT)
                    {
                        outputHand = new ThirteenOrphansTenpaiHandSingleWait(components);
                        AddWaitsToHand(hand, outputHand);
                        return outputHand;
                    }
                }

                outputHand = new ThirteenOrphansTenpaiHandThirteenWait(components);
                AddWaitsToHand(hand, outputHand);
                return outputHand;
            }

            return CreateSevenPairsHand(hand, components);
        }

        private static ITenpaiHand CreateSevenPairsHand(Hand hand, List<ICompleteHandComponent> components)
        {
            if (components.Count >= 6)
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
                    ITenpaiHand outputHand =  new SevenPairsTenpaiHand(components);
                    AddWaitsToHand(hand, outputHand);
                    return outputHand;
                }
            }
            return CreatePairWaitHand(hand, components);
        }

        private static ITenpaiHand CreatePairWaitHand(Hand hand, List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == ISOLATED_TILE)
                {
                    ITenpaiHand outputHand = new StandardTenpaiHandPairWait(components);
                    AddWaitsToHand(hand, outputHand);
                    return outputHand;
                }
            }

            return CreateTwoSidedTripletWaitHand(hand, components);
        }

        private static ITenpaiHand CreateTwoSidedTripletWaitHand(Hand hand, List<ICompleteHandComponent> components)
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
                ITenpaiHand outputHand =  new StandardTenpaiHandTwoSidedTripletWait(components);
                AddWaitsToHand(hand, outputHand);
                return outputHand;
            }

            return CreateClosedWaitHand(hand, components);
        }

        private static ITenpaiHand CreateClosedWaitHand(Hand hand, List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_CLOSED_WAIT)
                {
                    ITenpaiHand outputHand =  new StandardTenpaiHandClosedWait(components);
                    AddWaitsToHand(hand, outputHand);
                    return outputHand;
                }
            }

            return CreateEdgeWaitHand(hand, components);
        }

        private static ITenpaiHand CreateEdgeWaitHand(Hand hand, List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_EDGE_WAIT)
                {
                    ITenpaiHand outputHand = new StandardTenpaiHandEdgeWait(components);
                    AddWaitsToHand(hand, outputHand);
                    return outputHand;
                }
            }

            return CreateOpenWaitHand(hand, components);
        }

        private static ITenpaiHand CreateOpenWaitHand(Hand hand, List<ICompleteHandComponent> components)
        {
            foreach (ICompleteHandComponent component in components)
            {
                if (component.GetComponentType() == INCOMPLETE_SEQUENCE_OPEN_WAIT)
                {
                    ITenpaiHand outputHand = new StandardTenpaiHandOpenWait(components);
                    AddWaitsToHand(hand, outputHand);
                    return outputHand;
                }
            }

            throw new Exception("Hand does not form valid tenpai hand");
        }
        
        private static void AddWaitsToHand(Hand hand, ITenpaiHand outputHand)
        {
            foreach (TileObject tile in outputHand.GetWaits())
            {
                hand.AddWait(tile);
            }
        }
    }
}