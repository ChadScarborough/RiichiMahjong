using RMU.Wall.DeadWall;

namespace RMU.Hands
{
    public class StandardThreePlayerHand : AbstractThreePlayerHand
    {
        public StandardThreePlayerHand(Wall.Wall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}