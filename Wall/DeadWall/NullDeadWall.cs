using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Wall.DeadWall
{
    public class NullDeadWall : IDeadWall
    {
        public void Clear()
        {

        }

        public TileObject DrawTile()
        {
            return null;
        }

        public List<TileObject> GetDoraIndicators()
        {
            return null;
        }

        public List<TileObject> GetDrawableTiles()
        {
            return null;
        }

        public List<TileObject> GetRevealedDoraIndicators()
        {
            return null;
        }

        public List<TileObject> GetUraDoraIndicators()
        {
            return null;
        }

        public void PopulateDeadWall()
        {

        }

        public void RevealDoraTile()
        {

        }
    }
}
