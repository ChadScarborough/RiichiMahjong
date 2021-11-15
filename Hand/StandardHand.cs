using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Wall;
using RMU.Wall.DeadWall;
using RMU.DiscardPile;

namespace RMU.Hand
{
    public class StandardHand : IHand
    {
        private IWall _wall;
        private IDeadWall _deadWall;
        private List<TileObject> _closedTiles;
        private TileObject _drawTile;
        private const int MAX_NUMBER_OF_CLOSED_TILES = 13;
        private StandardDiscardPile _discardPile;
        private Algorithms.HandSorter _handSorter;

        public StandardHand(IWall wall, IDeadWall deadWall)
        {
            this._wall = wall;
            this._deadWall = deadWall;
            this._discardPile = new StandardDiscardPile();
            this._handSorter = new Algorithms.HandSorter();
        }

        public void DrawTileFromWall()
        {
            _drawTile = _wall.DrawTileFromWall();
        }

        public void DrawTileFromDeadWall()
        {
            _drawTile = _deadWall.DrawTile();
        }

        public void DiscardTile(int index)
        {
            _discardPile.DiscardTile(_closedTiles[index]);
            _closedTiles.RemoveAt(index);
            _closedTiles.Add(_drawTile);
            _drawTile = null;
            SortHand();
        }

        public void SortHand()
        {
            _closedTiles = _handSorter.SortHand(_closedTiles);
        }

        public TileObject GetDrawTile()
        {
            return _drawTile;
        }
    }
}
