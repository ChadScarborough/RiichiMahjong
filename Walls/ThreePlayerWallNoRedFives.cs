namespace RMU.Walls;

public sealed class ThreePlayerWallNoRedFives : Wall
{
    public ThreePlayerWallNoRedFives()
    {
        PopulateWall(TileLists.ThreePlayerWallNoRedFives());
        base.Shuffle();
    }
}