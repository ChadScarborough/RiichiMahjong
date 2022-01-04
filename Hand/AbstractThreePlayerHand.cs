using RMU.Hand.Calls;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;

namespace RMU.Hand
{
    public class AbstractThreePlayerHand : AbstractHand
    {
        public AbstractThreePlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }

        public void CallKita(TileObject calledTile)
        {
            ICallCommand callKita = new CallKitaCommand(this, calledTile);
            callKita.Execute();
        }
    }
}