﻿using RMU.Globals;

namespace RMU.Tiles
{
    public class WindTileObject : Tile
    {
        public WindTileObject(int value, Enums.Suit suit) : base(value, suit) { }

        public override bool IsTerminal()
        {
            return false;
        }

        public override bool IsHonor()
        {
            return true;
        }
    }
}
