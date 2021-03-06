using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
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
            return Enums.ISOLATED_TILE;
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.TILE;
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
