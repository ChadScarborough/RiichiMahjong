using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;
using static RMU.Globals.ConstValues;

namespace RMU.Hands.TenpaiHands;

public class ThirteenOrphansTenpaiHandSingleWait : ThirteenOrphansTenpaiHand
{
    private readonly TileObject[] _terminals = 
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

    public ThirteenOrphansTenpaiHandSingleWait(List<ICompleteHandComponent> components) : base(components)
    {
        SetWaits();
    }

    public override Enums.CompleteHandWaitType GetWaitType()
    {
        return Enums.PAIR_WAIT;
    }

    private void SetWaits()
    {
        _waits = new List<TileObject>();
        int[] counters = new int[NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS];
        CountAllTilesInHand(counters);
        FindMissingTileAndSetItAsWait(counters);
    }

    private void CountAllTilesInHand(int[] counters)
    {
        foreach (ICompleteHandComponent component in _components)
        {
            GetTileFromComponentAndIncrementAppropriateCounter(counters, component);
        }
    }

    private void GetTileFromComponentAndIncrementAppropriateCounter(int[] counters, ICompleteHandComponent component)
    {
        var tile = GetTileFromComponent(component);
        IncrementAppropriateCounter(counters, tile);
    }

    private static TileObject GetTileFromComponent(ICompleteHandComponent component)
    {
        TileObject tile = component.GetLeadTile();
        return tile;
    }

    private void IncrementAppropriateCounter(int[] counters, TileObject tile)
    {
        for (int i = 0; i < NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; i++)
        {
            if (AreTilesEquivalent(tile, _terminals[i]))
            {
                counters[i]++;
                break;
            }
        }
    }

    private void FindMissingTileAndSetItAsWait(int[] counters)
    {
        for (int j = 0; j < NUMBER_OF_UNIQUE_TERMINALS_AND_HONORS; j++)
        {
            if (counters[j] == 0)
            {
                _waits.Add(_terminals[j].Clone());
                return;
            }
        }
    }
}