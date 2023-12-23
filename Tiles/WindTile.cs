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

    public override string ToString()
    {
        return this._value switch
        {
            EAST_WIND_C  => "Wind_East",
            SOUTH_WIND_C => "Wind_South",
            WEST_WIND_C  => "Wind_West",
            _            => "Wind_North"
        };
    }
}
