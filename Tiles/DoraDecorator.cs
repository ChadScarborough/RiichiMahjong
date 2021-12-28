namespace RMU.Tiles
{
    public class DoraDecorator : TileDecorator
    {

        public DoraDecorator(TileObject tile) : base(tile) { }

        public override int GetDoraValue()
        {
            return _decoratee.GetDoraValue() + 1;
        }

        public override bool IsDoraTile()
        {
            return true;
        }
    }
}
