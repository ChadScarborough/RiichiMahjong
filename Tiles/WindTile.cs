namespace RMU.Tiles;

public sealed class WindTile : Tile
{
    public WindTile(int value, Suit suit) : base(value, suit) { }

    public override bool IsTerminal()
    {
        return false;
    }

    public override bool IsHonor()
    {
        return true;
    }
}
