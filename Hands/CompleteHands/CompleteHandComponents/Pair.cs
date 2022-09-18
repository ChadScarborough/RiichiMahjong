using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class PairComponent : ICompleteHandComponent
{
    private readonly List<Tile> _tiles;

    public PairComponent(List<Tile> pair)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in pair)
        {
            _tiles.Add(tile);
        }
        CheckForValidPair();
    }

    private void CheckForValidPair()
    {
        CheckForCorrectNumber();
        CheckThatTilesFormPair();
    }

    private void CheckForCorrectNumber()
    {
        if (_tiles.Count != 2)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
    }

    private void CheckThatTilesFormPair()
    {
        if (AreTilesEquivalent(_tiles[0], _tiles[1]) == false)
        {
            throw new ArgumentException("Tiles do not form pair");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return PAIR_COMPONENT;
    }

    public CompleteHandGeneralComponentType GetGeneralComponentType()
    {
        return PAIR;
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
