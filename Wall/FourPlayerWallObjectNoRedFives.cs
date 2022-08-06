using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class FourPlayerWallObjectNoRedFives : WallObject
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
}
