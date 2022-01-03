using RMU.Hand;
using RMU.Tiles;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public abstract class AbstractYaku
    {
        protected string _name;
        protected int _value;
        protected IGetNameBehaviour _getNameBehaviour;
        protected IGetValueBehaviour _getValueBehaviour;
        protected AbstractHand _hand;

        public abstract bool CheckYaku(AbstractHand hand, TileObject extraTile);
        public string GetName()
        {
            return _getNameBehaviour.GetName(_name);
        }

        public int GetValue(AbstractHand hand)
        {
            return _getValueBehaviour.GetValue(_value, hand);
        }
    }
}
