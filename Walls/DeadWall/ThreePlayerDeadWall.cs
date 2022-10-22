using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Walls.DeadWall
{
    public sealed class ThreePlayerDeadWall : IDeadWall
    {
        private const int NUMBER_OF_DORA_INDICATORS = 5;
        private const int NUMBER_OF_DRAWABLE_TILES = 4;
        private readonly List<Tile> _doraIndicators;
        private readonly List<Tile> _revealedDoraIndicators;
        private readonly List<Tile> _uraDoraIndicators;
        private readonly List<Tile> _drawableTiles;
        private readonly Wall _wall;

        public ThreePlayerDeadWall(Wall wall)
        {
            _wall = wall;
            _doraIndicators = new List<Tile>();
            _revealedDoraIndicators = new List<Tile>();
            _uraDoraIndicators = new List<Tile>();
            _drawableTiles = new List<Tile>();
            PopulateDeadWall();
        }

        public void Clear()
        {
            _doraIndicators.Clear();
            _revealedDoraIndicators.Clear();
            _uraDoraIndicators.Clear();
            _drawableTiles.Clear();
        }

        public Tile DrawTile()
        {
            Tile drawTile = _drawableTiles[0];
            _drawableTiles.RemoveAt(0);
            _drawableTiles.Add(_wall.DrawTileFromEndOfWall());
            return drawTile;
        }

        public List<Tile> GetDoraIndicators()
        {
            return _doraIndicators;
        }

        public List<Tile> GetDrawableTiles()
        {
            return _drawableTiles;
        }

        public int GetSize()
        {
            throw new NotImplementedException();
        }

        public List<Tile> GetRevealedDoraIndicators()
        {
            return _revealedDoraIndicators;
        }

        public List<Tile> GetUraDoraIndicators()
        {
            return _uraDoraIndicators;
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

        private void PopulateList(List<Tile> list, int quantity)
        {
            for (int i = 0; i < quantity; i++)
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
    }
}
