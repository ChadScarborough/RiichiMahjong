namespace RMU.Tiles.TileDecorators;

public sealed class UraDoraDecorator : TileDecorator
{
    public UraDoraDecorator(Tile tile) : base(tile) { }

    public override int GetUraDoraValue()
    {
        return _decoratee.GetUraDoraValue() + 1;
    }

    public override bool IsDoraTile()
    {
        return true;
    }

    public override bool IsRedFive()
    {
        return _decoratee.IsRedFive();
    }

    public override Tile Clone()
    {
        Tile clone = _decoratee.Clone();
        return new UraDoraDecorator(clone);
    }
}
