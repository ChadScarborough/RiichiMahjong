using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Wall
{
    public class StandardWall_ThreeRedFives : AbstractWall
    {
        public StandardWall_ThreeRedFives()
        {
            PopulateWall(TileLists.StandardWallThreeRedFives());
        }
    }
}
