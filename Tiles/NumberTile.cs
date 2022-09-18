namespace RMU.Tiles;

public sealed class NumberTile : Tile
{
    public NumberTile(int value, Suit suit) : base(value, suit) { }

    public override bool IsTerminal()
    {
        return _value is 1 or 9;
    }

    public override bool IsHonor()
    {
        return false;
    }

    public override Tile GetTileBelow()
    {
        return _value == 1 ? null : TileFactory.CreateTile(_value - 1, _suit);
    }

    public override Tile GetTileAbove()
    {
        return _value == 9 ? null : TileFactory.CreateTile(_value + 1, _suit);
    }
}
