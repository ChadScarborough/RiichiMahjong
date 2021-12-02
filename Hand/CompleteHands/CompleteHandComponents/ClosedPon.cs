using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedPon : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedPon(List<TileObject> closedPon)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in closedPon)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.ClosedPon;
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
