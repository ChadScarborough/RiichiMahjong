﻿using RMU.Calls.CreateMeldBehaviours;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hands.CompleteHands.CompleteHandComponents;

public sealed class ClosedKan : ICompleteHandGroup
{
    private readonly List<Tile> _tiles;

    public ClosedKan(OpenMeld closedKan)
    {
        _tiles = new List<Tile>();
        PopulateTilesList(closedKan);
        CheckForValidQuad();
    }

    private void CheckForValidQuad()
    {
        if (_tiles.Count != 4)
        {
            throw new ArgumentException("Incorrect number of tiles");
        }
        if (AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2], _tiles[3]) == false)
        {
            throw new ArgumentException("Tiles do not form quad");
        }
    }

    private void PopulateTilesList(OpenMeld closedKan)
    {
        foreach (Tile tile in closedKan.GetTiles())
        {
            _tiles.Add(tile);
        }
    }


    public CompleteHandComponentType GetComponentType()
    {
        return CLOSED_KAN_COMPONENT;
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
