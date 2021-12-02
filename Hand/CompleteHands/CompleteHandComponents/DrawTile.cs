using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
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
            return Enums.CompleteHandComponentType.DrawTile;
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
