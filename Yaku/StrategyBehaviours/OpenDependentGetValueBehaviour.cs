using RMU.Hand;

namespace RMU.Yaku.StrategyBehaviours
{
    public class OpenDependentGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, AbstractHand hand)
        {
            if (hand.IsOpen())
            {
                return value - 1;
            }
            return value;
        }
    }
}
