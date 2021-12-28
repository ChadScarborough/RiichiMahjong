namespace RMU.Tiles
{
    public abstract class TileDecorator : TileObject
    {
        protected TileObject _decoratee;

        public TileDecorator(TileObject tile) : base(tile.GetValue(), tile.GetSuit())
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

        public override TileObject GetTileAbove()
        {
            return _decoratee.GetTileAbove();
        }

        public override TileObject GetTileBelow()
        {
            return _decoratee.GetTileBelow();
        }
    }
}
