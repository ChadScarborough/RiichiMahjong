namespace RMU.Walls;

public sealed class FourPlayerWallThreeRedFives : Wall
{
    public FourPlayerWallThreeRedFives()
    {
        PopulateWall(TileLists.FourPlayerWallThreeRedFives());
        base.Shuffle();
    }
}
