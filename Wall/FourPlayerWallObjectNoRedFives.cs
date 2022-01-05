using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class FourPlayerWallObjectNoRedFives : WallObject
    {
        public FourPlayerWallObjectNoRedFives()
        {
            _wall = new FourPlayerWallNoRedFives();
            _deadWall = new FourPlayerDeadWall(_wall);
        }
    }
}