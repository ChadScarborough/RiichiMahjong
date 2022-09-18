using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class IncompleteSequenceOpenWait : ICompleteHandIncompleteGroup
{
    private readonly List<Tile> _tiles;

    public IncompleteSequenceOpenWait(List<Tile> incompleteSequenceOpenWait)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in incompleteSequenceOpenWait)
        {
            _tiles.Add(tile);
        }
        CheckForValidIncompleteSequenceOpenWait();
    }

    private void CheckForValidIncompleteSequenceOpenWait()
    {
        CheckForCorrectNumber();
        CheckForConsecutiveIncompleteSequence();
        CheckThatIncompleteSequenceIsNotEdgeWait();
    }

    private void CheckForCorrectNumber()
    {
        if (_tiles.Count != 2)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
    }

    private void CheckForConsecutiveIncompleteSequence()
    {
        if (AreTilesEquivalent(_tiles[0], GetTileBelow(_tiles[1])) == false)
        {
            throw new ArgumentException("Tiles do not form consecutive incomplete sequence");
        }
    }

    private void CheckThatIncompleteSequenceIsNotEdgeWait()
    {
        if (_tiles[0].GetValue() == 1 || _tiles[1].GetValue() == 9)
        {
            throw new ArgumentException("Tiles do not have open wait");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return INCOMPLETE_SEQUENCE_OPEN_WAIT;
    }

    public CompleteHandGeneralComponentType GetGeneralComponentType()
    {
        return TAATSU;
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
