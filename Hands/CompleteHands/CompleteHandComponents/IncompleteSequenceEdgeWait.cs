﻿using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class IncompleteSequenceEdgeWait : ICompleteHandIncompleteGroup
{
    private readonly List<Tile> _tiles;

    public IncompleteSequenceEdgeWait(List<Tile> incompleteSequenceEdgeWait)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in incompleteSequenceEdgeWait)
        {
            _tiles.Add(tile);
        }
        CheckForValidIncompleteSequenceEdgeWait();
    }

    private void CheckForValidIncompleteSequenceEdgeWait()
    {
        CheckForCorrectNumber();
        CheckThatTilesFormConsecutiveIncompleteSequence();
        CheckForEdgeWait();
    }

    private void CheckForCorrectNumber()
    {
        if (_tiles.Count != 2)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
    }

    private void CheckThatTilesFormConsecutiveIncompleteSequence()
    {
        if (AreTilesEquivalent(_tiles[0], GetTileBelow(_tiles[1])) == false)
        {
            throw new ArgumentException("Tiles do not form consecutive incomplete sequence");
        }
    }

    private void CheckForEdgeWait()
    {
        if (_tiles[0].GetValue() != 1 && _tiles[1].GetValue() != 9)
        {
            throw new ArgumentException("Not an edge wait");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return INCOMPLETE_SEQUENCE_EDGE_WAIT;
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
