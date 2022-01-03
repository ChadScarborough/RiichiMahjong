using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using RMU.Hand.Calls;
using static RMU.Globals.Functions;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenChii : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public OpenChii(OpenMeld openChii)
        { 
            _tiles = new List<TileObject>();
            foreach(TileObject tile in openChii.GetTiles())
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
            return Enums.OPEN_CHII;
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }

        public TileObject GetLeadTile()
        {
            return _tiles[0];
        }

        public Enums.CompleteHandGeneralComponentType GetGeneralComponentType()
        {
            return Enums.GROUP;
        }
    }
}
