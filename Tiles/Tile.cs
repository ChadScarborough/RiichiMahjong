namespace RMU.Tiles;
public abstract class Tile
{
    protected int _value;
    protected Suit _suit;

    public Tile(int value, Suit suit)
    {
        _value = value;
        _suit = suit;
    }

    public int GetValue()
    {
        return _value;
    }

    public Suit GetSuit()
    {
        return _suit;
    }

    public abstract bool IsTerminal();
    public abstract bool IsHonor();

    public bool IsTerminalOrHonor()
    {
        return IsTerminal() || IsHonor();
    }

    public virtual Tile GetTileBelow()
    {
        return null;
    }

    public virtual Tile GetTileAbove()
    {
        return null;
    }

    public virtual Tile Clone()
    {
        Suit suit = GetSuit();
        int value = GetValue();
        return TileFactory.CreateTile(value, suit);
    }

    public virtual int GetDoraValue()
    {
        return 0;
    }

    public virtual int GetUraDoraValue()
    {
        return 0;
    }

    public virtual bool IsDoraTile()
    {
        return false;
    }

    public virtual bool IsRedFive()
    {
        return false;
    }

    public override string ToString()
    {
        return _value.ToString() + " " + _suit.ToString();
    }
}

