using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

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
            bool isHighChii = meldType == Enums.MeldType.HighChii;
            bool isMidChii = meldType == Enums.MeldType.MidChii;
            bool isLowChii = meldType == Enums.MeldType.LowChii;
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
            return Enums.CompleteHandComponentType.OpenChii;
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
