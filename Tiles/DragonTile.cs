namespace RMU.Tiles;

public sealed class DragonTile : Tile
{
    public DragonTile(int value, Suit suit) : base(value, suit) { }

    public override bool IsTerminal()
    {
        return false;
    }

    public override bool IsHonor()
    {
        return true;
    }
}
