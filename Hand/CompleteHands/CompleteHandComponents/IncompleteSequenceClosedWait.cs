using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceClosedWait : ICompleteHandIncompleteGroup
    {
        private readonly List<TileObject> _tiles;

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
            return Enums.INCOMPLETE_SEQUENCE_CLOSED_WAIT;
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
