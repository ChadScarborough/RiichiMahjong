using RMU.Globals;

namespace RMU.Tiles
{
    public class WindTileObject : TileObject
    {
        public WindTileObject(int value, Enums.Suit suit)
        {
            this._value = value;
            this._suit = suit;
        }

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
