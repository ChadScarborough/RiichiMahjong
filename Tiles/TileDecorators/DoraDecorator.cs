namespace RMU.Tiles.TileDecorators;

public sealed class DoraDecorator : TileDecorator
{

    public DoraDecorator(Tile tile) : base(tile) { }

    public override int GetDoraValue()
    {
        return _decoratee.GetDoraValue() + 1;
    }

    public override bool IsDoraTile()
    {
        return true;
    }

    public override Tile Clone()
    {
        Tile clone = _decoratee.Clone();
        return new DoraDecorator(clone);
    }
}
