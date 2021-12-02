using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku
{
    public abstract class AbstractYaku
    {
        protected string _name;
        protected int _value;
        protected IGetNameBehaviour _getNameBehaviour;
        protected IGetValueBehaviour _getValueBehaviour;
        protected IHand _hand;

        public abstract bool CheckYaku(IHand hand, TileObject extraTile);
        public string GetName()
        {
            return _getNameBehaviour.GetName(_name);
        }

        public int GetValue(IHand hand)
        {
            return _getValueBehaviour.GetValue(_value, hand);
        }
    }
}
