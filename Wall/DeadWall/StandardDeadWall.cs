using System;
using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall.DeadWall
{
    public class StandardDeadWall : IDeadWall
    {
        private const int NUMBER_OF_DORA_INDICATORS = 5;
        private const int NUMBER_OF_DRAWABLE_TILES = 4;
        private List<TileObject> _doraIndicators;
        private List<TileObject> _revealedDoraIndicators;
        private List<TileObject> _uraDoraIndicators;
        private List<TileObject> _drawableTiles;
        private List<TileObject> _extraTiles;
        private IWall _wall;

        public StandardDeadWall(IWall wall)
        {
            this._wall = wall;
            _doraIndicators = new List<TileObject>();
            _revealedDoraIndicators = new List<TileObject>();
            _uraDoraIndicators = new List<TileObject>();
            _drawableTiles = new List<TileObject>();
            _extraTiles = new List<TileObject>();
            PopulateDeadWall();
        }

        public void PopulateDeadWall()
        {
            PopulateDoraIndicators();
            PopulateUraDoraIndicators();
            PopulateDrawableTiles();
            RevealDoraTile();
        }

        private void PopulateDoraIndicators()
        {
            for (int i = 0; i < NUMBER_OF_DORA_INDICATORS; i++)
            {
                _doraIndicators.Add(_wall.DrawTileFromEndOfWall());
            }
        }

        private void PopulateUraDoraIndicators()
        {
            for (int i = 0; i < NUMBER_OF_DORA_INDICATORS; i++)
            {
                _uraDoraIndicators.Add(_wall.DrawTileFromEndOfWall());
            }
        }

        private void PopulateDrawableTiles()
        {
            for (int i = 0; i < NUMBER_OF_DRAWABLE_TILES; i++)
            {
                _drawableTiles.Add(_wall.DrawTileFromEndOfWall());
            }
        }

        public void RevealDoraTile()
        {
            try
            {
                _revealedDoraIndicators.Add(_doraIndicators[_revealedDoraIndicators.Count]);
            }
            catch
            {
                throw new IndexOutOfRangeException("Revealed non-existent Dora tile");
            }
        }

        public TileObject DrawTile()
        {
            TileObject drawTile = _drawableTiles[_drawableTiles.Count - 1];
            _drawableTiles.Remove(drawTile);
            _extraTiles.Add(_wall.DrawTileFromEndOfWall());
            return drawTile;
        }

        public void Clear()
        {
            _doraIndicators.Clear();
            _revealedDoraIndicators.Clear();
            _uraDoraIndicators.Clear();
            _drawableTiles.Clear();
            _extraTiles.Clear();
        }

        public List<TileObject> GetDoraIndicators()
        {
            return _doraIndicators;
        }

        public List<TileObject> GetRevealedDoraIndicators()
        {
            return _revealedDoraIndicators;
        }

        public List<TileObject> GetUraDoraIndicators()
        {
            return _uraDoraIndicators;
        }

        public List<TileObject> GetDrawableTiles()
        {
            return _drawableTiles;
        }
    }
}
