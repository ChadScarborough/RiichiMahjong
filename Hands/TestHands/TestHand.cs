using RMU.Tiles;
using RMU.Walls;
using System.Collections.Generic;

namespace RMU.Hands.TestHands;

public abstract class TestHand : Hand
{
    protected TestHand() : base(new NullWallObject())
    {
    }

    public override List<Tile> GetClosedTiles()
    {
        return _closedTiles;
    }

    public override List<Tile> GetAllTiles(Tile extraTile)
    {
        List<Tile> outputList = new();
        foreach (Tile tile in _closedTiles)
        {
            outputList.Add(tile);
        }
        outputList.Add(extraTile);
        return outputList;
    }

    public override bool IsOpen()
    {
        return false;
    }
}
