using RMU.Hand.Calls;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMU.Hand
{
    public class AbstractFourPlayerHand : AbstractHand
    {
        public AbstractFourPlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
        
        public virtual void CallLowChii(TileObject calledTile)
        {
            ICallCommand callLowChiiCommand = new CallLowChiiCommand(this, calledTile);
            callLowChiiCommand.Execute();
        }
        
        public virtual void CallMidChii(TileObject calledTile)
        {
            ICallCommand callMidChiiCommand = new CallMidChiiCommand(this, calledTile);
            callMidChiiCommand.Execute();
        }
        
        public virtual void CallHighChii(TileObject calledTile)
        {
            ICallCommand callHighChiiCommand = new CallHighChiiCommand(this, calledTile);
            callHighChiiCommand.Execute();
        }
    }
}