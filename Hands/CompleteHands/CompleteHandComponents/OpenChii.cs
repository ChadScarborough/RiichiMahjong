﻿using RMU.Calls.CreateMeldBehaviours;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class OpenChii : ICompleteHandGroup
{
    private readonly List<Tile> _tiles;

    public OpenChii(OpenMeld openChii)
    {
        _tiles = new List<Tile>();
        foreach (Tile tile in openChii.GetTiles())
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
        return OPEN_CHII;
    }

    public List<Tile> GetTiles()
    {
        return _tiles;
    }

    public Tile GetLeadTile()
    {
        return _tiles[0];
    }

    public CompleteHandGeneralComponentType GetGeneralComponentType()
    {
        return GROUP;
    }
}
