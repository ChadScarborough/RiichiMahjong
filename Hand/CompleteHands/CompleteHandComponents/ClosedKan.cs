using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class ClosedKan : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public ClosedKan(OpenMeld closedKan)
        {
            CheckForCorrectMeldType(closedKan);
            _tiles = new List<TileObject>();
            PopulateTilesList(closedKan);
        }

        private void PopulateTilesList(OpenMeld closedKan)
        {
            foreach (TileObject tile in closedKan.GetTiles())
            {
                _tiles.Add(tile);
            }
        }

        private static void CheckForCorrectMeldType(OpenMeld closedKan)
        {
            if (closedKan.GetMeldType() != Enums.CLOSED_KAN_MELD)
            {
                throw new ArgumentException("Attempted to pass a meld other than a closed kan as a closed kan");
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
    }
}
