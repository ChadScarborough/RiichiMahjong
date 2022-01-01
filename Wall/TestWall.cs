using System.Collections.Generic;
using RMU.Tiles;
using RMU.DataStructures;
using RMU.Globals;

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
