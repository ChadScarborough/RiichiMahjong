﻿using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class IncompleteSequenceClosedWait : ICompleteHandIncompleteGroup
{
    private readonly List<Tile> _tiles;

    public IncompleteSequenceClosedWait(List<Tile> incompleteSequenceClosedWait)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in incompleteSequenceClosedWait)
        {
            _tiles.Add(tile);
        }
        CheckForValidIncompleteSequenceClosedWait();
    }

    private void CheckForValidIncompleteSequenceClosedWait()
    {
        CheckForCorrectNumber();
        CheckThatTilesFormIncompleteSequenceClosedWait();
    }

    private void CheckForCorrectNumber()
    {
        if (_tiles.Count != 2)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
    }

    private void CheckThatTilesFormIncompleteSequenceClosedWait()
    {
        if (AreTilesEquivalent(_tiles[0], GetTileTwoBelow(_tiles[1])) == false)
        {
            throw new ArgumentException("Tiles do not form incomplete sequence closed wait");
        }
    }

    public CompleteHandComponentType GetComponentType()
    {
        return INCOMPLETE_SEQUENCE_CLOSED_WAIT;
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
