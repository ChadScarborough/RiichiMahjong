﻿using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Walls.DeadWall;

public sealed class FourPlayerDeadWall : IDeadWall
{
    private const int NUMBER_OF_DORA_INDICATORS = 5;
    private const int NUMBER_OF_DRAWABLE_TILES = 4;
    private readonly List<Tile> _doraIndicators;
    private readonly List<Tile> _revealedDoraIndicators;
    private readonly List<Tile> _uraDoraIndicators;
    private readonly List<Tile> _drawableTiles;
    private readonly List<Tile> _extraTiles;
    private readonly Wall _wall;

    public FourPlayerDeadWall(Wall wall)
    {
        _wall = wall;
        _doraIndicators = new List<Tile>();
        _revealedDoraIndicators = new List<Tile>();
        _uraDoraIndicators = new List<Tile>();
        _drawableTiles = new List<Tile>();
        _extraTiles = new List<Tile>();
        PopulateDeadWall();
    }

    public void PopulateDeadWall()
    {
        PopulateDoraIndicators();
        PopulateUraDoraIndicators();
        PopulateDrawableTiles();
        RevealDoraTile();
    }

    private void PopulateDoraIndicators()
    {
        PopulateList(_doraIndicators, NUMBER_OF_DORA_INDICATORS);
    }

    private void PopulateUraDoraIndicators()
    {
        PopulateList(_uraDoraIndicators, NUMBER_OF_DORA_INDICATORS);
    }

    private void PopulateDrawableTiles()
    {
        PopulateList(_drawableTiles, NUMBER_OF_DRAWABLE_TILES);
    }

    private void PopulateList(List<Tile> list, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            list.Add(_wall.DrawTileFromEndOfWall());
        }
    }

    public void RevealDoraTile()
    {
        try
        {
            _revealedDoraIndicators.Add(_doraIndicators[_revealedDoraIndicators.Count]);
        }
        catch
        {
            throw new IndexOutOfRangeException("Revealed non-existent Dora tile");
        }
    }

    public Tile DrawTile()
    {
        Tile drawTile = _drawableTiles[^1];
        _ = _drawableTiles.Remove(drawTile);
        _extraTiles.Add(_wall.DrawTileFromEndOfWall());
        return drawTile;
    }

    public void Clear()
    {
        _doraIndicators.Clear();
        _revealedDoraIndicators.Clear();
        _uraDoraIndicators.Clear();
        _drawableTiles.Clear();
        _extraTiles.Clear();
    }

    public List<Tile> GetDoraIndicators()
    {
        return _doraIndicators;
    }

    public List<Tile> GetRevealedDoraIndicators()
    {
        return _revealedDoraIndicators;
    }

    public List<Tile> GetUraDoraIndicators()
    {
        return _uraDoraIndicators;
    }

    public List<Tile> GetDrawableTiles()
    {
        return _drawableTiles;
    }
}
