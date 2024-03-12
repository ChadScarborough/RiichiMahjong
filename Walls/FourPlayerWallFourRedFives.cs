namespace RMU.Walls;

public sealed class FourPlayerWallFourRedFives : Wall
{
    public FourPlayerWallFourRedFives()
    {
        PopulateWall(TileLists.FourPlayerWallFourRedFives());
        base.Shuffle();
    }
}