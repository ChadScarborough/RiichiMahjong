using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenPon : ICompleteHandGroup
    {
        private List<TileObject> _tiles;

        public OpenPon(OpenMeld openPon)
        {
            CheckForCorrectMeldType(openPon);
            _tiles = new List<TileObject>();
            foreach(TileObject tile in openPon.GetTiles())
            {
                _tiles.Add(tile);
            }
        }

        private static void CheckForCorrectMeldType(OpenMeld openPon)
        {
            Enums.MeldType meldType = openPon.GetMeldType();
            if(meldType != Enums.MeldType.Pon)
            {
                throw new ArgumentException("Attempted to pass a meld other than an open pon as an open pon");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.CompleteHandComponentType.OpenPon;
        }

        public List<TileObject> GetTiles()
        {
            return _tiles;
        }
    }
}
