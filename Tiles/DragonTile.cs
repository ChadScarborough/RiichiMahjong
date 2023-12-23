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

    public override string ToString()
    {
        return this._value switch
        {
            GREEN_DRAGON_C => "Dragon_Green",
            RED_DRAGON_C   => "Dragon_Red",
            _              => "Dragon_White"
        };
    }
}
