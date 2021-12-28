using System;
using RMU.Globals;
using RMU.Tiles;
using System.Collections.Generic;
using static RMU.Globals.Functions;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedChii : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedChii(List<TileObject> closedChii)
        {
            _tiles = new List<TileObject>();
            foreach (TileObject tile in closedChii)
            {
                _tiles.Add(tile);
            }
            CheckForValidSequence();
        }

        private void CheckForValidSequence()
        {
            CheckForCorrectNumberOfTiles();
            CheckThatTilesFormSequence();
        }

        private void CheckThatTilesFormSequence()
        {
            if(DoTilesFormValidSequence(_tiles[0], _tiles[1], _tiles[2]) == false)
            {
                throw new ArgumentException("Tiles do not form valid sequence");
            }
        }

        private void CheckForCorrectNumberOfTiles()
        {
            if (_tiles.Count != 3) { throw new ArgumentException("Incorrect number of tiles"); }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CLOSED_CHII;
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
