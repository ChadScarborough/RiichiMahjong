using System;
using System.Collections.Generic;
using RMU.DataStructures;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Wall
{
    public class StandardWall : AbstractWall
    {
        public StandardWall()
        {
            PopulateWall(TileLists.StandardWallNoRedFives());
        }
    }
}
