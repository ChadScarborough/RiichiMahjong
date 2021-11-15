using RMU.DataStructures;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public interface IWall
    {
        TileObject DrawTileFromEndOfWall();
        TileObject DrawTileFromWall();
        void PopulateWall();
        int GetSize();
        void Clear();
    }
}