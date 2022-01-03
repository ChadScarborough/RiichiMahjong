using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using RMU.Hand.Calls;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedKan : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedKan(OpenMeld closedKan)
        {
            _tiles = new List<TileObject>();
            PopulateTilesList(closedKan);
            CheckForValidQuad();
        }

        private void CheckForValidQuad()
        {
            if(_tiles.Count != 4)
            {
                throw new ArgumentException("Incorrect number of tiles");
            }
            if(Functions.AreTilesEquivalent(_tiles[0], _tiles[1], _tiles[2], _tiles[3]) == false)
            {
                throw new ArgumentException("Tiles do not form quad");
            }
        }

        private void PopulateTilesList(OpenMeld closedKan)
        {
            foreach (TileObject tile in closedKan.GetTiles())
            {
                _tiles.Add(tile);
            }
        }


        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CLOSED_KAN_COMPONENT;
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
