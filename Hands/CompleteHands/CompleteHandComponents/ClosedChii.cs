using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class ClosedChii : ICompleteHandGroup
{
    private readonly List<Tile> _tiles;

    public ClosedChii(List<Tile> closedChii)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in closedChii)
        {
            _tiles.Add(tile);
        }
        CheckForValidSequence();
    }

    private void CheckForValidSequence()
    {
        CheckForCorrectNumberOfTiles();
        CheckThatTilesFormSequence();
    }

    private void CheckThatTilesFormSequence()
    {
        if (DoTilesFormValidSequence(_tiles[0], _tiles[1], _tiles[2]) == false)
        {
            throw new ArgumentException("Tiles do not form valid sequence");
        }
    }

    private void CheckForCorrectNumberOfTiles()
    {
        if (_tiles.Count != 3) { throw new ArgumentException("Incorrect number of tiles"); }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return CLOSED_CHII;
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
