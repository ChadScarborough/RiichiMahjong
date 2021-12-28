using RMU.Globals;

namespace RMU.Tiles
{
    public class DragonTileObject : TileObject
    {
        public DragonTileObject(int value, Enums.Suit suit) : base(value, suit) { }

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
