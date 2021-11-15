using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Wall.DeadWall
{
    public interface IDeadWall
    {
        TileObject DrawTile();
        void PopulateDeadWall();
        void RevealDoraTile();
        void Clear();
        List<TileObject> GetDoraIndicators();
        List<TileObject> GetRevealedDoraIndicators();
        List<TileObject> GetUraDoraIndicators();
        List<TileObject> GetDrawableTiles();
    }
}