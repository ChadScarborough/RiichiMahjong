using RMU.Globals;

namespace RMU.Tiles
{
    public abstract class TileObject
    {
        protected int _value;
        protected Enums.Suit _suit;

        public TileObject(int _value, Enums.Suit _suit)
        {
            this._value = _value;
            this._suit = _suit;
        }

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
            Enums.Suit suit = GetSuit();
            int value = GetValue();
            return TileFactory.CreateTile(value, suit);
        }

        public virtual int GetDoraValue()
        {
            return 0;
        }

        public virtual int GetUraDoraValue()
        {
            return 0;
        }

        public virtual bool IsDoraTile()
        {
            return false;
        }

        public virtual bool IsRedFive()
        {
            return false;
        }
    }
}
