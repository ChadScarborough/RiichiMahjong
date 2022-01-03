using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using static RMU.Globals.Enums;

namespace RMU.Hand
{
    public class AbstractFourPlayerHand : AbstractHand
    {
        public AbstractFourPlayerHand(AbstractWall wall, IDeadWall deadWall) : base(wall, deadWall)
        {
        }
        
        public virtual void CallLowChii(TileObject calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(calledTile, LOW_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(calledTile.GetValue() - (i + 1), calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }
        
        public virtual void CallMidChii(TileObject calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(calledTile, MID_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(calledTile.GetValue() - ((2 * i) - 1), calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }
        
        public virtual void CallHighChii(TileObject calledTile)
        {
            _isOpen = true;
            CreateOpenMeld(calledTile, HIGH_CHII);
            for (int i = 0; i < 2; i++)
            {
                TileObject tempTile = TileFactory.CreateTile(calledTile.GetValue() + (i + 1), calledTile.GetSuit());
                RemoveCopyOfTile(tempTile);
            }
        }
    }
}