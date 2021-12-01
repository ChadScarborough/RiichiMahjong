using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedChii : ICompleteHandGroup
    {
        private List<TileObject> _tiles;

        public ClosedChii(List<TileObject> closedChii)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in closedChii)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.ClosedChii;
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
