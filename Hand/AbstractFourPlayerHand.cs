using RMU.Hand.Calls;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMU.Hand
{
    public class AbstractFourPlayerHand : AbstractHand
    {
        protected AbstractFourPlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}