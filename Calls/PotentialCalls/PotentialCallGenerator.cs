using RMU.Hands;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Tiles.TileDecorators;
using RMU.Yaku;
using static RMU.Calls.PotentialCalls.PotentialCallFactory;

namespace RMU.Calls.PotentialCalls;

public static class PotentialCallGenerator
{
    public static void GeneratePotentialPonAndKanCalls(Player player, PriorityQueueForPotentialCalls queue, Tile lastTile)
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
        if (ContainsExactTile(hand, oneBelow) && ContainsExactTile(hand, twoBelow))
        {
            queue.AddCall(CreatePotentialCall(player, LOW_CHII_POTENTIAL_CALL_TYPE));
        }
        if (oneBelow.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(oneBelow)))
                queue.AddCall(CreatePotentialCall(player, LOW_CHII_RED_POTENTIAL_CALL_TYPE));
        }
        else if (twoBelow.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(twoBelow)))
                queue.AddCall(CreatePotentialCall(player, LOW_CHII_RED_POTENTIAL_CALL_TYPE));
        }
    }

    public static void GeneratePotentialMidChiiCall(Player player, PriorityQueueForPotentialCalls queue,
        Tile lastTile)
    {
        List<Tile> hand = player.GetHand().GetClosedTiles();
        Tile oneBelow = GetTileBelow(lastTile);
        Tile oneAbove = GetTileAbove(lastTile);
        if (ContainsExactTile(hand, oneBelow) && ContainsExactTile(hand, oneAbove))
        {
            queue.AddCall(CreatePotentialCall(player, MID_CHII_POTENTIAL_CALL_TYPE));
        }
        if (oneBelow.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(oneBelow)))
                queue.AddCall(CreatePotentialCall(player, MID_CHII_RED_POTENTIAL_CALL_TYPE));
        }
        else if (oneAbove.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(oneAbove)))
                queue.AddCall(CreatePotentialCall(player, MID_CHII_RED_POTENTIAL_CALL_TYPE));
        }
    }

    public static void GeneratePotentialHighChiiCall(Player player, PriorityQueueForPotentialCalls queue,
        Tile lastTile)
    {
        List<Tile> hand = player.GetHand().GetClosedTiles();
        Tile oneAbove = GetTileAbove(lastTile);
        Tile twoAbove = GetTileTwoBelow(lastTile);
        if (ContainsExactTile(hand, oneAbove) && ContainsExactTile(hand, twoAbove))
        {
            queue.AddCall(CreatePotentialCall(player, HIGH_CHII_POTENTIAL_CALL_TYPE));
        }
        if (oneAbove.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(oneAbove)))
                queue.AddCall(CreatePotentialCall(player, HIGH_CHII_RED_POTENTIAL_CALL_TYPE));
        }
        else if (twoAbove.GetValue() == 5)
        {
            if (ContainsExactTile(hand, new RedFiveDecorator(twoAbove)))
                queue.AddCall(CreatePotentialCall(player, HIGH_CHII_RED_POTENTIAL_CALL_TYPE));
        }
    }

    private static bool IsNonRedFive(Tile tile)
    {
        return tile.GetValue() == 5 && tile.IsRedFive() == false;
    }

    public static void GeneratePotentialRonCall(Player player, PriorityQueueForPotentialCalls queue,
        Tile lastTile)
    {
        if (player.GetHand().GetShanten() != 0)
        {
            return;
        }

        List<ICompleteHand> completeHands = GetAllCompleteHandsForRonCheck(player, lastTile);
        if (AtLeastOneYakuSatisfied(completeHands) == false)
        {
            return;
        }

        DetermineStrongestCompleteHand(completeHands, player);
        queue.AddCall(CreatePotentialCall(player, RON_POTENTIAL_CALL_TYPE));
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
                    break;
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

    private static bool ContainsExactTile(List<Tile> hand, Tile tile)
    {
        foreach (Tile t in hand)
        {
            if (t.GetValue() != tile.GetValue())
                continue;
            if (t.GetSuit() != tile.GetSuit())
                continue;
            if (t.IsRedFive() != tile.IsRedFive())
                continue;
            return true;
        }
        return false;
    }
}