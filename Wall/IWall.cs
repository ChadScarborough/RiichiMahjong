using RMU.Tiles;

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