using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class FourPlayerWallObjectThreeRedFives : WallObject
    {
        public FourPlayerWallObjectThreeRedFives()
        {
            _wall = new FourPlayerWallThreeRedFives();
            _deadWall = new FourPlayerDeadWall(_wall);
        }
    }
}