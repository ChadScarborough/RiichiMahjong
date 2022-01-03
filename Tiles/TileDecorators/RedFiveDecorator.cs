using RMU.Globals;

namespace RMU.Tiles.TileDecorators
{
    public class RedFiveDecorator : TileDecorator
    {
        public RedFiveDecorator(TileObject tile) : base(tile) { }

        public override bool IsDoraTile()
        {
            return true;
        }

        public override bool IsRedFive()
        {
            return true;
        }

        public override TileObject Clone()
        {
            TileObject clone = _decoratee.Clone();
            return new RedFiveDecorator(clone);
        }
    }
}
