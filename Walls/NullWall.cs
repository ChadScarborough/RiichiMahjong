using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Walls;

public sealed class NullWall : Wall
{
    public override Tile DrawTileFromWall()
    {
        return null;
    }

    public override Tile DrawTileFromEndOfWall()
    {
        return null;
    }

    public override int GetSize()
    {
        return 0;
    }

    public override List<Tile> GetWallTiles()
    {
        return null;
    }
}