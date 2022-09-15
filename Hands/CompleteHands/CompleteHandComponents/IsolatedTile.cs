using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class IsolatedTile : ICompleteHandComponent
    {
        private readonly Tile _tile;

        public IsolatedTile(Tile isolatedTile)
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

        public Tile GetLeadTile()
        {
            return _tile;
        }

        public List<Tile> GetTiles()
        {
            return new List<Tile> { _tile };
        }

        
    }
}
