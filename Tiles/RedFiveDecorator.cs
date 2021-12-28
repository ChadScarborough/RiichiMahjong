namespace RMU.Tiles
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
    }
}
