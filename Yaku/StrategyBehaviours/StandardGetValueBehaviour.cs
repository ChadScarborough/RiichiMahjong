using RMU.Hands;

namespace RMU.Yaku.StrategyBehaviours
{
    public class StandardGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, Hand hand)
        {
            return value;
        }
    }
}
