using RMU.Hands;

namespace RMU.Yaku.StrategyBehaviours
{
    public class OpenDependentGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, Hand hand)
        {
            if (hand.IsOpen())
            {
                return value - 1;
            }
            return value;
        }
    }
}
