﻿using RMU.Globals.DataStructures;
using RMU.Tiles;
using System.Linq;

namespace RMU.Walls;

public abstract class Wall
{
    protected Wall()
    {
        _wall = new DoublyLinkedList<Tile>();
    }

    private readonly DoublyLinkedList<Tile> _wall;

    public virtual Tile DrawTileFromWall()
    {
        return DrawTile(_wall);
    }

    private Tile DrawTile(DoublyLinkedList<Tile> wall)
    {
        return wall.RemoveHead();
    }

    public virtual Tile DrawTileFromEndOfWall()
    {
        return DrawTileFromEnd(_wall);
    }

    private Tile DrawTileFromEnd(DoublyLinkedList<Tile> wall)
    {
        return wall.RemoveTail();
    }

    public void PopulateWall(IEnumerable<Tile> tiles)
    {
        Clear();
        List<Tile> tempList = GenerateTiles(tiles);
        FillWall(tempList, _wall);
    }

    private static void FillWall(List<Tile> source, DoublyLinkedList<Tile> destination)
    {
        destination.Clear();
        foreach (Tile tile in source)
        {
            destination.AddTail(tile);
        }
    }

    private static List<Tile> GenerateTiles(IEnumerable<Tile> tiles)
    {
        return tiles.Select(tile => tile.Clone()).ToList();
    }

    public virtual int GetSize()
    {
        return _wall.GetSize();
    }

    private void Clear()
    {
        _wall.Clear();
    }

    public virtual List<Tile> GetWallTiles()
    {
        List<Tile> outputList = new();
        DoublyLinkedList<Tile>.Node node = _wall.GetHead();
        while (node != null)
        {
            outputList.Add(node.GetValue());
            node = node.GetNext();
        }

        return outputList;
    }

    public void AddTile(Tile tile)
    {
        _wall.AddHead(tile);
    }

    public Tile Peek()
    {
        return _wall.GetHead().GetValue();
    }
}