using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class PairComponent : ICompleteHandComponent
    {
        private readonly List<Tile> _tiles;

        public PairComponent(List<Tile> pair)
        {
            _tiles = new List<Tile>();
            foreach(Tile tile in pair)
            {
                _tiles.Add(tile);
            }
            CheckForValidPair();
        }

        private void CheckForValidPair()
        {
            CheckForCorrectNumber();
            CheckThatTilesFormPair();
        }

        private void CheckForCorrectNumber()
        {
            if(_tiles.Count != 2)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
        }

        private void CheckThatTilesFormPair()
        {
            if(Functions.AreTilesEquivalent(_tiles[0], _tiles[1]) == false)
            {
                throw new ArgumentException("Tiles do not form pair");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.PAIR_COMPONENT;
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.PAIR;
        }

        public Tile GetLeadTile()
        {
            return _tiles[0];
        }

        public List<Tile> GetTiles()
        {
            return _tiles;
        }
    }
}
