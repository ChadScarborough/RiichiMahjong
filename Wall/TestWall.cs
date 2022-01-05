using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall
{
    public class TestWall : Wall
    {
        public TestWall(List<TileObject> tiles)
        {
            PopulateWall(tiles);
        }
    }
}
