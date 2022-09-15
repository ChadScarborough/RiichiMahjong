using RMU.Globals;

namespace RMU.Tiles
{
    public class NumberTileObject : Tile
    {
        public NumberTileObject(int value, Enums.Suit suit) : base(value, suit) { }

        public override bool IsTerminal()
        {
            return _value == 1 || _value == 9;
        }

        public override bool IsHonor()
        {
            return false;
        }

        public override Tile GetTileBelow()
        {
            if (_value == 1) return null;
            return TileFactory.CreateTile(_value - 1, _suit);
        }

        public override Tile GetTileAbove()
        {
            if (_value == 9) return null;
            return TileFactory.CreateTile(_value + 1, _suit);
        }
    }
}
