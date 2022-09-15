using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall
{
    public class TestWall : Wall
    {
        public TestWall(List<Tile> tiles)
        {
            PopulateWall(tiles);
        }
    }
}
