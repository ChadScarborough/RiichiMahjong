using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class FourPlayerWallObjectFourRedFives : WallObject
    {
        public FourPlayerWallObjectFourRedFives()
        {
            _wall = new FourPlayerWallFourRedFives();
            _deadWall = new FourPlayerDeadWall(_wall);
        }
    }
}