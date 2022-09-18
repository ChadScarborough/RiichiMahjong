using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class ClosedPon : ICompleteHandGroup
{
    private readonly List<Tile> _tiles;

    public ClosedPon(List<Tile> closedPon)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in closedPon)
        {
            _tiles.Add(tile);
        }
        CheckForValidTriplet();
    }

    private void CheckForValidTriplet()
    {
        if (AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2]) == false)
        {
            throw new ArgumentException("Tiles do not form valid triplet");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return CLOSED_PON;
    }

    public CompleteHandGeneralComponentType GetGeneralComponentType()
    {
        return GROUP;
    }

    public Tile GetLeadTile()
    {
        return _tiles[0];
    }

    public List<Tile> GetTiles()
    {
        return _tiles;
    }
}
