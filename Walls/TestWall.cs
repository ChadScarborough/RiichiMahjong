using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Walls;

public sealed class TestWall : Wall
{
    public TestWall(List<Tile> tiles)
    {
        PopulateWall(tiles);
    }
}
