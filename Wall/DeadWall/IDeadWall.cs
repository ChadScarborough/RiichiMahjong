using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Wall.DeadWall
{
    public interface IDeadWall
    {
        Tile DrawTile();
        void PopulateDeadWall();
        void RevealDoraTile();
        void Clear();
        List<Tile> GetDoraIndicators();
        List<Tile> GetRevealedDoraIndicators();
        List<Tile> GetUraDoraIndicators();
        List<Tile> GetDrawableTiles();
    }
}