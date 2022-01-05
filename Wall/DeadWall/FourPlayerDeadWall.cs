using System;
using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Wall.DeadWall
{
    public class FourPlayerDeadWall : IDeadWall
    {
        private const int NUMBER_OF_DORA_INDICATORS = 5;
        private const int NUMBER_OF_DRAWABLE_TILES = 4;
        private List<TileObject> _doraIndicators;
        private List<TileObject> _revealedDoraIndicators;
        private List<TileObject> _uraDoraIndicators;
        private List<TileObject> _drawableTiles;
        private List<TileObject> _extraTiles;
        private Wall _wall;

        public FourPlayerDeadWall(Wall wall)
        {
            _wall = wall;
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
            PopulateList(_doraIndicators, NUMBER_OF_DORA_INDICATORS);
        }

        private void PopulateUraDoraIndicators()
        {
            PopulateList(_uraDoraIndicators, NUMBER_OF_DORA_INDICATORS);
        }

        private void PopulateDrawableTiles()
        {
            PopulateList(_drawableTiles, NUMBER_OF_DRAWABLE_TILES);
        }

        private void PopulateList(List<TileObject> list, int quantity)
        {
            for(int i = 0; i < quantity; i++)
            {
                list.Add(_wall.DrawTileFromEndOfWall());
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
