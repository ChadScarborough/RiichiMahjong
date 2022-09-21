using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class FourPlayerWallObjectFourRedFives : WallObject
{
    public FourPlayerWallObjectFourRedFives()
    {
        _wall = new FourPlayerWallFourRedFives();
        GenerateDeadWall();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new FourPlayerDeadWall(_wall);
    }
}