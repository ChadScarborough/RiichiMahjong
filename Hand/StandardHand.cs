using System.Collections.Generic;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.DiscardPile;
using RMU.Globals;

namespace RMU.Hand
{
    public class StandardHand : AbstractHand
    {
        public StandardHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
            
        }
    }
}
