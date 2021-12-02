using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class Pair : ICompleteHandComponent
    {
        private readonly List<TileObject> _tiles;

        public Pair(List<TileObject> pair)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in pair)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.Pair;
        }

        public TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
