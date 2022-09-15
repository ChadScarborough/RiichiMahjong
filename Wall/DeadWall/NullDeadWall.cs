using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Wall.DeadWall
{
    public class NullDeadWall : IDeadWall
    {
        public void Clear()
        {

        }

        public Tile DrawTile()
        {
            return null;
        }

        public List<Tile> GetDoraIndicators()
        {
            return null;
        }

        public List<Tile> GetDrawableTiles()
        {
            return null;
        }

        public List<Tile> GetRevealedDoraIndicators()
        {
            return null;
        }

        public List<Tile> GetUraDoraIndicators()
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
