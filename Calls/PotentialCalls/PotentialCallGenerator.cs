using System;
using System.Collections.Generic;
using RMU.Hands;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.Functions;
using static RMU.Globals.Enums;
using static RMU.Calls.PotentialCalls.PotentialCallFactory;

namespace RMU.Calls.PotentialCalls
{
    public static class PotentialCallGenerator
    {
        public static void GeneratePotentialPonAndKanCalls(Player player, PriorityQueueForPotentialCalls queue,
            TileObject lastTile)
        {
            Hand hand = player.GetHand();
            int counter = 0;
            foreach (TileObject tile in hand.GetClosedTiles())
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
            TileObject lastTile)
        {
            List<TileObject> hand = player.GetHand().GetClosedTiles();
            TileObject oneBelow = GetTileBelow(lastTile);
            TileObject twoBelow = GetTileTwoBelow(lastTile);
            if (ContainsTile(hand, oneBelow) && ContainsTile(hand, twoBelow))
            {
                queue.AddCall(CreatePotentialCall(player, LOW_CHII_POTENTIAL_CALL_TYPE));
            }
        }
        
        public static void GeneratePotentialMidChiiCall(Player player, PriorityQueueForPotentialCalls queue,
            TileObject lastTile)
        {
            List<TileObject> hand = player.GetHand().GetClosedTiles();
            TileObject oneBelow = GetTileBelow(lastTile);
            TileObject oneAbove = GetTileAbove(lastTile);
            if (ContainsTile(hand, oneAbove) && ContainsTile(hand, oneBelow))
            {
                queue.AddCall(CreatePotentialCall(player, MID_CHII_POTENTIAL_CALL_TYPE));
            }
        }
        
        public static void GeneratePotentialHighChiiCall(Player player, PriorityQueueForPotentialCalls queue,
            TileObject lastTile)
        {
            List<TileObject> hand = player.GetHand().GetClosedTiles();
            TileObject oneAbove = GetTileAbove(lastTile);
            TileObject twoAbove = GetTileTwoBelow(lastTile);
            if (ContainsTile(hand, oneAbove) && ContainsTile(hand, twoAbove))
            {
                queue.AddCall(CreatePotentialCall(player, HIGH_CHII_POTENTIAL_CALL_TYPE));
            }
        }

        public static void GeneratePotentialRonCall(Player player, PriorityQueueForPotentialCalls queue,
            TileObject lastTile)
        {
            //if(hand.IsTenpai() && ContainsTile(hand.GetWaits(), lastTile)
            //{
            //  queue.AddCall(CreatePotentialCall(player, RON_POTENTIAL_CALL_TYPE));
            //}
        }

        private static bool ContainsTile(List<TileObject> hand, TileObject tile)
        {
            foreach (TileObject t in hand)
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