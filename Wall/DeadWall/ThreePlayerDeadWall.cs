using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMU.Wall.DeadWall
{
    public class ThreePlayerDeadWall : IDeadWall
    {
        private const int NUMBER_OF_DORA_INDICATORS = 5;
        private const int NUMBER_OF_DRAWABLE_TILES = 4;
        private readonly List<TileObject> _doraIndicators;
        private readonly List<TileObject> _revealedDoraIndicators;
        private readonly List<TileObject> _uraDoraIndicators;
        private readonly List<TileObject> _drawableTiles;
        private readonly Wall _wall;

        public ThreePlayerDeadWall(Wall wall)
        {
            _wall = wall;
            _doraIndicators = new List<TileObject>();
            _revealedDoraIndicators = new List<TileObject>();
            _uraDoraIndicators = new List<TileObject>();
            _drawableTiles = new List<TileObject>();
            PopulateDeadWall();
        }

        public void Clear()
        {
            _doraIndicators.Clear();
            _revealedDoraIndicators.Clear();
            _uraDoraIndicators.Clear();
            _drawableTiles.Clear();
        }

        public TileObject DrawTile()
        {
            TileObject drawTile = _drawableTiles[0];
            _drawableTiles.RemoveAt(0);
            _drawableTiles.Add(_wall.DrawTileFromEndOfWall());
            return drawTile;
        }

        public List<TileObject> GetDoraIndicators()
        {
            return _doraIndicators;
        }

        public List<TileObject> GetDrawableTiles()
        {
            return _drawableTiles;
        }

        public List<TileObject> GetRevealedDoraIndicators()
        {
            return _revealedDoraIndicators;
        }

        public List<TileObject> GetUraDoraIndicators()
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

        private void PopulateList(List<TileObject> list, int quantity)
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
