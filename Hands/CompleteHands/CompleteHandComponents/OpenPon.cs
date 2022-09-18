using RMU.Calls.CreateMeldBehaviours;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class OpenPon : ICompleteHandGroup
{
    private readonly List<Tile> _tiles;

    public OpenPon(OpenMeld openPon)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in openPon.GetTiles())
        {
            _tiles.Add(tile);
        }
        CheckForValidTriplet();
    }

    private void CheckForValidTriplet()
    {
        CheckForCorrectNumber();
        CheckThatTilesFormTriplet();
    }

    private void CheckForCorrectNumber()
    {
        if (_tiles.Count != 3)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
    }

    private void CheckThatTilesFormTriplet()
    {
        if (AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2]) == false)
        {
            throw new ArgumentException("Tiles do not form triplet");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return OPEN_PON;
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
