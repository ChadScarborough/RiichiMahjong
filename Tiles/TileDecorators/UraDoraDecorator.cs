namespace RMU.Tiles.TileDecorators
{
    public class UraDoraDecorator : TileDecorator
    {
        public UraDoraDecorator(TileObject tile) : base(tile) { }

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

        public override TileObject Clone()
        {
            TileObject clone = _decoratee.Clone();
            return new UraDoraDecorator(clone);
        }
    }
}
