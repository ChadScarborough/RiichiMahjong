using RMU.Tiles;
using RMU.Walls.DeadWall;

namespace RMU.TestObjects.TestWalls;

public sealed class NullDeadWall : IDeadWall
{
    public void Clear()
    {

    }

    public Tile DrawTile()
    {
        return null;
    }

    public List<Tile> GetDoraIndicators()
    {
        return null;
    }

    public List<Tile> GetDrawableTiles()
    {
        return null;
    }

    public int GetSize()
    {
        return 0;
    }

    public List<Tile> GetRevealedDoraIndicators()
    {
        return null;
    }

    public List<Tile> GetUraDoraIndicators()
    {
        return null;
    }

    public void PopulateDeadWall()
    {

    }

    public void RevealDoraTile()
    {

    }
}
