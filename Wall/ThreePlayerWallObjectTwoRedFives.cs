using RMU.Wall.DeadWall;

namespace RMU.Wall
{
    public class ThreePlayerWallObjectTwoRedFives : WallObject
    {
        public ThreePlayerWallObjectTwoRedFives()
        {
            _wall = new ThreePlayerWallTwoRedFives();
        }

        public override void GenerateDeadWall()
        {
            _deadWall = new ThreePlayerDeadWall(_wall);
        }
    }
}
