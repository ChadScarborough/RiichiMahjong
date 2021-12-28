using System;
using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class PairComponent : ICompleteHandComponent
    {
        private readonly List<TileObject> _tiles;

        public PairComponent(List<TileObject> pair)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in pair)
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

        public TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
