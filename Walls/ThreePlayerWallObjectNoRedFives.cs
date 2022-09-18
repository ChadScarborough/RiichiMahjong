using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class ThreePlayerWallObjectNoRedFives : WallObject
{
    public ThreePlayerWallObjectNoRedFives()
    {
        _wall = new ThreePlayerWallNoRedFives();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new ThreePlayerDeadWall(_wall);
    }
}
