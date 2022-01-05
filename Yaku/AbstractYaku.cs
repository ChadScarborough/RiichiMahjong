using RMU.Hands;
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
        protected Hand _hand;

        public abstract bool CheckYaku(Hand hand, TileObject extraTile);
        public string GetName()
        {
            return _getNameBehaviour.GetName(_name);
        }

        public int GetValue(Hand hand)
        {
            return _getValueBehaviour.GetValue(_value, hand);
        }
    }
}
