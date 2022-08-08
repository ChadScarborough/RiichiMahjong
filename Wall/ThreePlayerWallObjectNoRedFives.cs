using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class ThreePlayerWallObjectNoRedFives : WallObject
    {
        public ThreePlayerWallObjectNoRedFives()
        {
            _wall = new ThreePlayerWallNoRedFives();
        }

        public override void GenerateDeadWall()
        {
            _deadWall = new ThreePlayerDeadWall(_wall);
        }
    }
}
