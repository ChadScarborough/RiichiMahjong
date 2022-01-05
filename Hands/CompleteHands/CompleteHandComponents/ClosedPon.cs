using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class ClosedPon : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedPon(List<TileObject> closedPon)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in closedPon)
            {
                _tiles.Add(tile);
            }
            CheckForValidTriplet();
        }

        private void CheckForValidTriplet()
        {
            if(Functions.AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2]) == false)
            {
                throw new ArgumentException("Tiles do not form valid triplet");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CLOSED_PON;
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
