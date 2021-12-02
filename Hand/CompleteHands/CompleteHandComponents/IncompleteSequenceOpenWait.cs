using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IncompleteSequenceOpenWait : ICompleteHandIncompleteGroup
    {
        private readonly List<TileObject> _tiles;

        public IncompleteSequenceOpenWait(List<TileObject> incompleteSequenceOpenWait)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in incompleteSequenceOpenWait)
            {
                _tiles.Add(tile);
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.IncompleteSequenceOpenWait;
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
