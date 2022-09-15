using System.Collections.Generic;
using RMU.Hands;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Functions;
using static RMU.Globals.Enums;
using static RMU.Calls.PotentialCalls.PotentialCallFactory;
using RMU.Hands.CompleteHands;
using System;
using RMU.Globals;
using RMU.Hands.TenpaiHands;
using RMU.Yaku.StandardYaku;

namespace RMU.Calls.PotentialCalls
{
    public static class PotentialCallGenerator
    {
        public static void GeneratePotentialPonAndKanCalls(Player player, PriorityQueueForPotentialCalls queue,
            Tile lastTile)
        {
            Hand hand = player.GetHand();
            int counter = 0;
            foreach (Tile tile in hand.GetClosedTiles())
            {
                if (AreTilesEquivalent(lastTile, tile))
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                queue.AddCall(CreatePotentialCall(player, PON_POTENTIAL_CALL_TYPE));
            }

            if (counter >= 3)
            {
                queue.AddCall(CreatePotentialCall(player, OPEN_KAN_1_POTENTIAL_CALL_TYPE));
            }
        }

        public static void GeneratePotentialLowChiiCall(Player player, PriorityQueueForPotentialCalls queue,
            Tile lastTile)
        {
            List<Tile> hand = player.GetHand().GetClosedTiles();
            Tile oneBelow = GetTileBelow(lastTile);
            Tile twoBelow = GetTileTwoBelow(lastTile);
            if (ContainsTile(hand, oneBelow) && ContainsTile(hand, twoBelow))
            {
                queue.AddCall(CreatePotentialCall(player, LOW_CHII_POTENTIAL_CALL_TYPE));
            }
        }
        
        public static void GeneratePotentialMidChiiCall(Player player, PriorityQueueForPotentialCalls queue,
            Tile lastTile)
        {
            List<Tile> hand = player.GetHand().GetClosedTiles();
            Tile oneBelow = GetTileBelow(lastTile);
            Tile oneAbove = GetTileAbove(lastTile);
            if (ContainsTile(hand, oneAbove) && ContainsTile(hand, oneBelow))
            {
                queue.AddCall(CreatePotentialCall(player, MID_CHII_POTENTIAL_CALL_TYPE));
            }
        }
        
        public static void GeneratePotentialHighChiiCall(Player player, PriorityQueueForPotentialCalls queue,
            Tile lastTile)
        {
            List<Tile> hand = player.GetHand().GetClosedTiles();
            Tile oneAbove = GetTileAbove(lastTile);
            Tile twoAbove = GetTileTwoBelow(lastTile);
            if (ContainsTile(hand, oneAbove) && ContainsTile(hand, twoAbove))
            {
                queue.AddCall(CreatePotentialCall(player, HIGH_CHII_POTENTIAL_CALL_TYPE));
            }
        }

        public static void GeneratePotentialRonCall(Player player, PriorityQueueForPotentialCalls queue,
            Tile lastTile)
        {
            if (player.GetHand().GetShanten() != 0) return;
            List<ICompleteHand> completeHands = GetAllCompleteHandsForRonCheck(player, lastTile);
            if (AtLeastOneYakuSatisfied(completeHands) == false) return;
            queue.AddCall(CreatePotentialCall(player, RON_POTENTIAL_CALL_TYPE));
            DetermineStrongestCompleteHand(completeHands, player);
        }

        private static bool AtLeastOneYakuSatisfied(List<ICompleteHand> completeHands)
        {
            bool yakuSatisfied = false;
            foreach (ICompleteHand completeHand in completeHands)
            {
                StandardYakuList yakuList = new(completeHand);
                List<YakuBase> satisfiedYaku = yakuList.CheckYaku();
                completeHand.SetYaku(satisfiedYaku);
                if (satisfiedYaku.Count > 0) yakuSatisfied = true;
            }
            return yakuSatisfied;
        }

        private static List<ICompleteHand> GetAllCompleteHandsForRonCheck(Player player, Tile lastTile)
        {
            List<ICompleteHand> completeHands = new();
            Hand hand = player.GetHand();
            foreach (ITenpaiHand tenpaiHand in hand.GetTenpaiHands())
            {
                foreach (Tile waitTile in tenpaiHand.GetWaits())
                {
                    if (AreTilesEquivalent(waitTile, lastTile))
                    {
                        completeHands.Add(CompleteHandFactory.CreateCompleteHand(tenpaiHand, lastTile, player));
                    }
                }
            }

            return completeHands;
        }

        private static void DetermineStrongestCompleteHand(List<ICompleteHand> completeHands, Player player)
        {
            ICompleteHand strongestHand = completeHands[0];
            int highestValue = 0;
            foreach (ICompleteHand completeHand in completeHands)
            {
                int han = 0;
                foreach (YakuBase yaku in completeHand.GetYaku())
                {
                    han += yaku.GetValue();
                }
                if (han > highestValue)
                {
                    highestValue = han;
                    strongestHand = completeHand;
                }
            }
            player.SetCompleteHand(strongestHand);
            player.SetSatisfiedYaku(strongestHand.GetYaku());
        }

        private static bool ContainsTile(List<Tile> hand, Tile tile)
        {
            foreach (Tile t in hand)
            {
                if (AreTilesEquivalent(t, tile))
                {
                    return true;
                }
            }

            return false;
        }
    }
}