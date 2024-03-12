namespace RMU.Walls;

public sealed class FourPlayerWallNoRedFives : Wall
{
    public FourPlayerWallNoRedFives()
    {
        PopulateWall(TileLists.FourPlayerWallNoRedFives());
        base.Shuffle();
    }
}
