using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Shanten;

public static class UniqueTerminals
{
    private static int _counter;
    private static readonly int[] _terminals = new int[NUMBER_OF_DIFFERENT_TERMINALS];
    private const int
        ONE_MAN = 0,
        NINE_MAN = 1,
        ONE_PIN = 2,
        NINE_PIN = 3,
        ONE_SOU = 4,
        NINE_SOU = 5,
        EAST = 6,
        SOUTH = 7,
        WEST = 8,
        NORTH = 9,
        GREEN = 10,
        RED = 11,
        WHITE = 12,
        NUMBER_OF_DIFFERENT_TERMINALS = 13;

    private static readonly object terminalLock = new();

    public static int NumberOfUniqueTerminals(List<Tile> tiles)
    {
        lock (terminalLock)
        {
            ClearCounters();
            IncrementCountersForEachTerminal(tiles);
            CountUniqueTerminals();
            return _counter;
        }
    }

    private static void CountUniqueTerminals()
    {
        for (int i = 0; i < NUMBER_OF_DIFFERENT_TERMINALS; i++)
        {
            IncrementCounter(i);
        }
    }

    private static void IncrementCounter(int index)
    {
        if (_terminals[index] > 0)
        {
            _counter++;
        }
    }

    private static void IncrementCountersForEachTerminal(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            CheckIfTileIsTerminalOrHonorAndIncrementAppropriateCounter(tile);
        }
    }

    private static void CheckIfTileIsTerminalOrHonorAndIncrementAppropriateCounter(Tile tile)
    {
        if (CheckIfTileIsTerminalAndIncrementAppropriateCounter(tile))
        {
            return;
        }

        CheckIfTileIsHonorAndIncrementAppropriateCounter(tile);
    }

    private static void CheckIfTileIsHonorAndIncrementAppropriateCounter(Tile tile)
    {
        if (tile.IsHonor())
        {
            FindHonorTileValueAndIncrementAppropriateCounter(tile);
        }
    }

    private static void FindHonorTileValueAndIncrementAppropriateCounter(Tile tile)
    {
        switch (tile.GetValue())
        {
            case 1:
                FindExactHonorTileValueAndIncrementOneOfTwoCounters(tile, EAST, GREEN);
                return;
            case 2:
                FindExactHonorTileValueAndIncrementOneOfTwoCounters(tile, SOUTH, RED);
                return;
            case 3:
                FindExactHonorTileValueAndIncrementOneOfTwoCounters(tile, WEST, WHITE);
                return;
            case 4:
                _terminals[NORTH]++;
                return;
        }
    }

    private static void FindExactHonorTileValueAndIncrementOneOfTwoCounters(Tile tile, int counter1, int counter2)
    {
        if (tile.GetSuit() is WIND)
        {
            _terminals[counter1]++;
            return;
        }
        _terminals[counter2]++;
    }

    private static bool CheckIfTileIsTerminalAndIncrementAppropriateCounter(Tile tile)
    {
        if (tile.IsTerminal())
        {
            FindTerminalTileValueAndIncrementAppropriateCounter(tile);
            return true;
        }
        return false;
    }

    private static void FindTerminalTileValueAndIncrementAppropriateCounter(Tile tile)
    {
        switch (tile.GetSuit())
        {
            case MAN:
                FindExactTerminalTileValueAndIncrementOneOfTwoCounters(tile, ONE_MAN, NINE_MAN);
                return;
            case PIN:
                FindExactTerminalTileValueAndIncrementOneOfTwoCounters(tile, ONE_PIN, NINE_PIN);
                return;
            case SOU:
                FindExactTerminalTileValueAndIncrementOneOfTwoCounters(tile, ONE_SOU, NINE_SOU);
                return;
        }
    }

    private static void FindExactTerminalTileValueAndIncrementOneOfTwoCounters(Tile tile, int counter1, int counter2)
    {
        if (tile.GetValue() == 1)
        {
            _terminals[counter1]++;
            return;
        }
        _terminals[counter2]++;
    }

    private static void ClearCounters()
    {
        for (int i = 0; i < NUMBER_OF_DIFFERENT_TERMINALS; i++)
        {
            _terminals[i] = 0;
        }
        _counter = 0;
    }
}
