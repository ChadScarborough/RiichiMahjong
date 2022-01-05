using System;
using System.Collections.Generic;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class OpenPon : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public OpenPon(OpenMeld openPon)
        {
            _tiles = new List<TileObject>();
            foreach(TileObject tile in openPon.GetTiles())
            {
                _tiles.Add(tile);
            }
            CheckForValidTriplet();
        }

        private void CheckForValidTriplet()
        {
            CheckForCorrectNumber();
            CheckThatTilesFormTriplet();
        }

        private void CheckForCorrectNumber()
        {
            if(_tiles.Count != 3)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
        }

        private void CheckThatTilesFormTriplet()
        {
            if(Functions.AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2]) == false)
            {
                throw new ArgumentException("Tiles do not form triplet");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.OPEN_PON;
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.GROUP;
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
