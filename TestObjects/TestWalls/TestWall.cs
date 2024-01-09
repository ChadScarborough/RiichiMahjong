using RMU.Tiles;
using RMU.Walls;

namespace RMU.TestObjects.TestWalls;

public sealed class TestWall : Wall
{
    public TestWall(List<Tile> tiles)
    {
        PopulateWall(tiles);
    }
}
