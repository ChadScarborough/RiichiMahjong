using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenChii : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public OpenChii(OpenMeld openChii)
        {
            CheckForCorrectMeldType(openChii);
            _tiles = new List<TileObject>();
            foreach(TileObject tile in openChii.GetTiles())
            {
                _tiles.Add(tile);
            }
        }

        private void CheckForCorrectMeldType(OpenMeld openChii)
        {
            Enums.MeldType meldType = openChii.GetMeldType();
            bool isHighChii = meldType == Enums.HIGH_CHII;
            bool isMidChii = meldType == Enums.MID_CHII;
            bool isLowChii = meldType == Enums.LOW_CHII;
            ThrowExceptionOnIncorrectMeldType(isHighChii, isMidChii, isLowChii);
        }

        private static void ThrowExceptionOnIncorrectMeldType(bool isHighChii, bool isMidChii, bool isLowChii)
        {
            if ((isHighChii || isMidChii || isLowChii) == false)
            {
                throw new ArgumentException("Attempted to pass a meld other than an open chii as an open chii");
            }
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
    }
}
