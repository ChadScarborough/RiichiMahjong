﻿using RMU.Tiles;
using System;
using System.Collections.Generic;
using System.Text;
using RMU.Globals;

namespace RMU.Hand
{
    public class CreateLowChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile)
        {
            TileFactory tileFactory = new TileFactory();
            int value = _calledTile.GetValue();
            Enums.Suit suit = _calledTile.GetSuit();

            TileObject lowTile = tileFactory.CreateTile(value - 2, suit);
            TileObject midTile = tileFactory.CreateTile(value - 1, suit);
            return new List<TileObject> { lowTile, midTile, _calledTile };
        }
    }
}
