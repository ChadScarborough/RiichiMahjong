using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall
{
    public class TestWall : AbstractWall
    {
        public TestWall(List<TileObject> tiles)
        {
            PopulateWall(tiles);
        }
    }
}
