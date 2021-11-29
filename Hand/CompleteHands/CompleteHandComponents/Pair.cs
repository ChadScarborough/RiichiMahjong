using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class Pair : ICompleteHandComponent
    {
        private List<TileObject> _tiles;

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

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
