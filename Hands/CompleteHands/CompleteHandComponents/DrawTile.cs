using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class DrawTile : ICompleteHandComponent
    {
        private readonly TileObject _tile;

        public DrawTile(TileObject drawTile)
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
