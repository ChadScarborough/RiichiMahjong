using RMU.Wall.DeadWall;

namespace RMU.Hands
{
    public class AbstractFourPlayerHand : Hand
    {
        protected AbstractFourPlayerHand(Wall.Wall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}