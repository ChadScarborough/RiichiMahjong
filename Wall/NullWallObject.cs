using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class NullWallObject : WallObject
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
    }
}