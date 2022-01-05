using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public abstract class WallObject
    {
        protected Wall _wall;
        protected IDeadWall _deadWall;

        public Wall GetWall()
        {
            return _wall;
        }

        public IDeadWall GetDeadWall()
        {
            return _deadWall;
        }
    }
}