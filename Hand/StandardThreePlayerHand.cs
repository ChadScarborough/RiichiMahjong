using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMU.Hand
{
    public class StandardThreePlayerHand : AbstractThreePlayerHand
    {
        public StandardThreePlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
    }
}