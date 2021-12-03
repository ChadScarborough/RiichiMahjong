﻿using RMU.Globals;
using RMU.Tiles;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public class OpenPon : ICompleteHandGroup
    {
        private readonly List<TileObject> _tiles;

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
            if(meldType != Enums.PON)
            {
                throw new ArgumentException("Attempted to pass a meld other than an open pon as an open pon");
            }
        }

        public Enums.CompleteHandComponentType GetComponentType()
        {
            return Enums.OPEN_PON;
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
