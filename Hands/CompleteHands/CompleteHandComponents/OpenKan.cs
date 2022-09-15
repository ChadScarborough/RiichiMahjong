using System;
using System.Collections.Generic;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Hands.CompleteHands.CompleteHandComponents
{
    public class OpenKan : ICompleteHandGroup
    {
        private readonly List<Tile> _tiles;

        public OpenKan(OpenMeld openKan)
        {
            _tiles = new List<Tile>();
            foreach (Tile tile in openKan.GetTiles())
            {
                _tiles.Add(tile);
            }
            CheckForValidQuad();
        }

        private void CheckForValidQuad()
        {
            CheckForCorrectNumber();
            CheckThatTilesFormQuad();
        }

        private void CheckForCorrectNumber()
        {
            if(_tiles.Count != 4)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
        }

        private void CheckThatTilesFormQuad()
        {
            if(Functions.AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2], _tiles[3]) == false)
            {
                throw new ArgumentException("Tiles do not form quad");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.OPEN_KAN;
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
