using RMU.Hands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Shanten.HandSplitter;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class ThirteenOrphansShantenCalculator
{
    private static readonly Tile[] TerminalsAndHonors =
    {
        ONE_MAN, NINE_MAN,
        ONE_PIN, NINE_PIN,
        ONE_SOU, NINE_SOU,
        EAST_WIND, SOUTH_WIND,
        WEST_WIND, NORTH_WIND,
        GREEN_DRAGON,
        RED_DRAGON,
        WHITE_DRAGON
    };

    private static readonly int[] Counters = new int[13];
    private static int _uniqueTerminals;
    private static bool _isDuplicateTerminal;
    private static List<ICompleteHandComponent> _components;
    private static List<TileCollection> _collections;

    private static readonly object shantenLock = new();

    public static int CalculateShanten(Hand hand, List<TileCollection> collections)
    {
        lock (shantenLock)
        {
            _collections = collections;
            _components = new List<ICompleteHandComponent>();
            ResetCounters();
            CountTerminalsAndHonors(collections);
            CalculateUniqueTerminalsAndWhetherThereAreDuplicates();
            int shanten = ShantenFormulas.CalculateThirteenOrphansShanten(_uniqueTerminals, _isDuplicateTerminal);
            if (shanten == 0)
            {
                ExtractComponentsFromHand();
                hand.AddTenpaiHand(TenpaiHandFactory.CreateTenpaiHand(hand, _components));
            }

            return shanten;
        }
    }

    private static void ExtractComponentsFromHand()
    {
        foreach (TileCollection collection in _collections)
        {
            foreach (ICompleteHandComponent component in PairExtractor.ExtractPair(collection))
            {
                _components.Add(component);
            }
        }

        foreach (TileCollection collection in _collections)
        {
            foreach (ICompleteHandComponent component in IsolatedTileExtractor.ExtractIsolatedTiles(collection))
            {
                _components.Add(component);
            }
        }
    }

    private static void CalculateUniqueTerminalsAndWhetherThereAreDuplicates()
    {
        foreach (int i in Counters)
        {
            CheckForNewTerminalAndIncrementCounter(i);

            CheckForDuplicateTerminalAndSetBoolToTrue(i);
        }
    }

    private static void CheckForDuplicateTerminalAndSetBoolToTrue(int i)
    {
        if (i > 1)
        {
            _isDuplicateTerminal = true;
        }
    }

    private static void CheckForNewTerminalAndIncrementCounter(int i)
    {
        if (i > 0)
        {
            _uniqueTerminals++;
        }
    }

    private static void CountTerminalsAndHonors(List<TileCollection> collections)
    {
        foreach (TileCollection collection in collections)
        {
            CheckCollectionForTerminalsOrHonors(collection);
        }
    }

    private static void CheckCollectionForTerminalsOrHonors(TileCollection collection)
    {
        foreach (Tile tile in collection.GetTiles())
        {
            CheckIfTileIsTerminalOrHonorAndIncrementAppropriateCounter(tile);
        }
    }

    private static void CheckIfTileIsTerminalOrHonorAndIncrementAppropriateCounter(Tile tile)
    {
        if (TileIsNotTerminalOrHonor(tile))
        {
            return;
        }

        for (int i = 0; i < NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; i++)
        {
            if (IncrementAppropriateCounterIfTileIsTerminalOrHonor(tile, i))
            {
                return;
            }
        }
    }

    private static bool TileIsNotTerminalOrHonor(Tile tile)
    {
        return (tile.IsHonor() || tile.IsTerminal()) == false;
    }

    private static bool IncrementAppropriateCounterIfTileIsTerminalOrHonor(Tile tile, int i)
    {
        if (AreTilesEquivalent(TerminalsAndHonors[i], tile))
        {
            Counters[i]++;
            return true;
        }

        return false;
    }

    private static void ResetCounters()
    {
        for (int i = 0; i < NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; i++)
        {
            Counters[i] = 0;
        }

        _uniqueTerminals = 0;
        _isDuplicateTerminal = false;
    }
}