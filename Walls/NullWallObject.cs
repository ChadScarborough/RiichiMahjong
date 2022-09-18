using RMU.Walls.DeadWall;

namespace RMU.Walls;

public sealed class NullWallObject : WallObject
{
    public NullWallObject()
    {
        _wall = new NullWall();
        _deadWall = new NullDeadWall();
    }

    public override Wall GetWall()
    {
        return new NullWall();
    }

    public override IDeadWall GetDeadWall()
    {
        return new NullDeadWall();
    }

    public override void GenerateDeadWall()
    {
        throw new System.NotImplementedException();
    }
}