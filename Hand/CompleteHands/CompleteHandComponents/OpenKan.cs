using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenKan : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

        public OpenKan(OpenMeld openKan)
        {
            CheckForCorrectMeldType(openKan);
            _tiles = new List<TileObject>();
            foreach (TileObject tile in openKan.GetTiles())
            {
                _tiles.Add(tile);
            }
        }

        private static void CheckForCorrectMeldType(OpenMeld openKan)
        {
            Enums.MeldType meldType = openKan.GetMeldType();
            bool isOpenKan1 = meldType == Enums.OPEN_KAN_1;
            bool isOpenKan2 = meldType == Enums.OPEN_KAN_2;
            ThrowExceptionOnIncorrectMeldType(isOpenKan1, isOpenKan2);
        }

        private static void ThrowExceptionOnIncorrectMeldType(bool isOpenKan1, bool isOpenKan2)
        {
            if (isOpenKan1 == false && isOpenKan2 == false)
            {
                throw new ArgumentException("Attempted to pass a meld other than an open kan as an open kan");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.OPEN_KAN;
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
