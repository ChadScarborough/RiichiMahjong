using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class FourPlayerWallObjectThreeRedFives : WallObject
{
    public FourPlayerWallObjectThreeRedFives()
    {
        _wall = new FourPlayerWallThreeRedFives();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new FourPlayerDeadWall(_wall);
    }
}