using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class IsolatedTile : ICompleteHandComponent
    {
        private readonly TileObject _tile;

        public IsolatedTile(TileObject isolatedTile)
        {
            _tile = isolatedTile;
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.IsolatedTile;
        }

        public TileObject GetLeadTile()
        {
            return _tile;
        }

        public List<TileObject> GetTiles()
        {
            return new List<TileObject> { _tile };
        }
    }
}
