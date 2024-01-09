using Godot;
using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class FourPlayerWallObjectNoRedFives : WallObject
{
    public FourPlayerWallObjectNoRedFives()
    {
        _wall = new FourPlayerWallNoRedFives();
    }

    public override void GenerateDeadWall()
    {
        _deadWall = new FourPlayerDeadWall(_wall);
    }
}
