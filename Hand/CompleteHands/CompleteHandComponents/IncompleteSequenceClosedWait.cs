using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceClosedWait : ICompleteHandIncompleteGroup
    {
        private List<TileObject> _tiles;

        public IncompleteSequenceClosedWait(List<TileObject> incompleteSequenceClosedWait)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in incompleteSequenceClosedWait)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.IncompleteSequenceClosedWait;
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
