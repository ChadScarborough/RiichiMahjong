using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall
{
    public class NullWall : Wall
    {
        public override TileObject DrawTileFromWall()
        {
            return null;
        }

        public override TileObject DrawTileFromEndOfWall()
        {
            return null;
        }

        public override int GetSize()
        {
            return 0;
        }

        public override List<TileObject> GetWallTiles()
        {
            return null;
        }
    }
}