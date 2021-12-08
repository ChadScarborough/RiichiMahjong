using RMU.Globals;

namespace RMU.Tiles
{
    public abstract class TileObject
    {
        protected int _value;
        protected Enums.Suit _suit;
     

        public int GetValue()
        {
            return _value;
        }

        public Enums.Suit GetSuit()
        {
            return _suit;
        }

        public abstract bool IsTerminal();
        public abstract bool IsHonor();
        public virtual TileObject GetTileBelow()
        {
            return null;
        }
        public virtual TileObject GetTileAbove()
        {
            return null;
        }
        
        public TileObject Clone()
        {
            Enums.Suit suit = this.GetSuit();
            int value = this.GetValue()
            return TileFactory.CreateTile(value, suit);
        }
    }
}
