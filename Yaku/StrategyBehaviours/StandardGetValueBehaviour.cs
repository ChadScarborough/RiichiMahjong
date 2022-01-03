using RMU.Hand;

namespace RMU.Yaku.StrategyBehaviours
{
    public class StandardGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, AbstractHand hand)
        {
            return value;
        }
    }
}
