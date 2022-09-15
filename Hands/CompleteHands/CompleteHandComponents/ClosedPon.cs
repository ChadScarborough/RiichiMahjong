using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class ClosedPon : ICompleteHandGroup
    {
        private readonly List<Tile> _tiles;

        public ClosedPon(List<Tile> closedPon)
        {
            _tiles = new List<Tile>();
            foreach (Tile tile in closedPon)
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
