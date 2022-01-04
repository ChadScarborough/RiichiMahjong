using RMU.Hand.Calls;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMU.Hand
{
    public class AbstractThreePlayerHand : AbstractHand
    {
        protected AbstractThreePlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}