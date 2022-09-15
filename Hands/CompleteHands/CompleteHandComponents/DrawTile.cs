using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class DrawTile : ICompleteHandComponent
    {
        private readonly Tile _tile;

        public DrawTile(Tile drawTile)
        {
            _tile = drawTile;
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.DRAW_TILE;
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
