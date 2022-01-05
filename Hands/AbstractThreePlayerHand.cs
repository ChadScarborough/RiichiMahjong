using RMU.Wall.DeadWall;

namespace RMU.Hands
{
    public class AbstractThreePlayerHand : Hand
    {
        protected AbstractThreePlayerHand(Wall.Wall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}