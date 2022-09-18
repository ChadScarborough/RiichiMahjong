namespace RMU.Tiles.TileDecorators;

public abstract class TileDecorator : Tile
{
    protected Tile _decoratee;

    public TileDecorator(Tile tile) : base(tile.GetValue(), tile.GetSuit())
    {
        _decoratee = tile;
    }

    public override bool IsHonor()
    {
        return _decoratee.IsHonor();
    }

    public override bool IsTerminal()
    {
        return _decoratee.IsTerminal();
    }

    public override int GetDoraValue()
    {
        return _decoratee.GetDoraValue();
    }

    public override int GetUraDoraValue()
    {
        return _decoratee.GetUraDoraValue();
    }

    public override bool IsDoraTile()
    {
        return _decoratee.IsDoraTile();
    }

    public override bool IsRedFive()
    {
        return _decoratee.IsRedFive();
    }

    public override Tile GetTileAbove()
    {
        return _decoratee.GetTileAbove();
    }

    public override Tile GetTileBelow()
    {
        return _decoratee.GetTileBelow();
    }
}
