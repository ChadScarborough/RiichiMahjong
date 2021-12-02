using RMU.Hand;

namespace RMU.Yaku
{
    public class OpenDependentGetValueBehaviour : IGetValueBehaviour
    {
        public int GetValue(int value, IHand hand)
        {
            if (hand.IsOpen())
            {
                return value - 1;
            }
            return value;
        }
    }
}
