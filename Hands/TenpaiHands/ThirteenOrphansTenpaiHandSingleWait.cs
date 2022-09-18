using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public sealed class ThirteenOrphansTenpaiHandSingleWait : ThirteenOrphansTenpaiHand
{
    private readonly Tile[] _terminals =
    {
        ONE_MAN, NINE_MAN,
        ONE_PIN, NINE_PIN,
        ONE_SOU, NINE_SOU,
        EAST_WIND, SOUTH_WIND,
        WEST_WIND, NORTH_WIND,
        GREEN_DRAGON, RED_DRAGON, WHITE_DRAGON
    };

    public ThirteenOrphansTenpaiHandSingleWait(List<ICompleteHandComponent> components) : base(components)
    {
        SetWaits();
    }

    public override CompleteHandWaitType GetWaitType()
    {
        return SINGLE_WAIT;
    }

    private void SetWaits()
    {
        _waits = new List<Tile>();
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
        Tile tile = GetTileFromComponent(component);
        IncrementAppropriateCounter(counters, tile);
    }

    private static Tile GetTileFromComponent(ICompleteHandComponent component)
    {
        Tile tile = component.GetLeadTile();
        return tile;
    }

    private void IncrementAppropriateCounter(int[] counters, Tile tile)
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
                SetTileAsWait(j);
                return;
            }
        }
    }

    private void SetTileAsWait(int j)
    {
        _waits.Add(_terminals[j].Clone());
    }
}