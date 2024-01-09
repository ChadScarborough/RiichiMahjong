using RMU.Tiles;
using System;

namespace RMU.Walls.DeadWall;

public interface IDeadWall
{
    public event EventHandler OnDoraTileRevealed;
    Tile DrawTile();
    void PopulateDeadWall();
    void RevealDoraTile();
    void Clear();
    List<Tile> GetDoraIndicators();
    List<Tile> GetRevealedDoraIndicators();
    List<Tile> GetUraDoraIndicators();
    List<Tile> GetDrawableTiles();
    int GetSize();
}