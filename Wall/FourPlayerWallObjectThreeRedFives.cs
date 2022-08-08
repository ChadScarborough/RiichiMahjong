using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class FourPlayerWallObjectThreeRedFives : WallObject
    {
        public FourPlayerWallObjectThreeRedFives()
        {
            _wall = new FourPlayerWallThreeRedFives();
            
        }

        public override void GenerateDeadWall()
        {
            _deadWall = new FourPlayerDeadWall(_wall);
        }
    }
}