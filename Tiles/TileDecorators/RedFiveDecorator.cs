namespace RMU.Tiles.TileDecorators;

public sealed class RedFiveDecorator : TileDecorator
{
    public RedFiveDecorator(Tile tile) : base(tile) { }

    public override bool IsDoraTile()
    {
        return true;
    }

    public override bool IsRedFive()
    {
        return true;
    }

    public override Tile Clone()
    {
        Tile clone = _decoratee.Clone();
        return new RedFiveDecorator(clone);
    }
}
