using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class ThreePlayerWallObjectTwoRedFives : WallObject
{
    public ThreePlayerWallObjectTwoRedFives()
    {
        _wall = new ThreePlayerWallTwoRedFives();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new ThreePlayerDeadWall(_wall);
    }
}
