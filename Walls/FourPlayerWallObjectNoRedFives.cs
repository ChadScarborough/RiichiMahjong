using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class FourPlayerWallObjectNoRedFives : WallObject
{
    public FourPlayerWallObjectNoRedFives()
    {
        _wall = new FourPlayerWallNoRedFives();
        GenerateDeadWall();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new FourPlayerDeadWall(_wall);
    }
}
