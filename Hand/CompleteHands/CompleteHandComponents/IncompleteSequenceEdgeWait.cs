using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceEdgeWait : ICompleteHandIncompleteGroup
    {
        private List<TileObject> _tiles;

        public IncompleteSequenceEdgeWait(List<TileObject> incompleteSequenceEdgeWait)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in incompleteSequenceEdgeWait)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.IncompleteSequenceEdgeWait;
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
