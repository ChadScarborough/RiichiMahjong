using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Yaku.StandardYaku;

public sealed class FullyOutsideHandYaku : YakuBase
{
    public FullyOutsideHandYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Fully Outside Hand";
        _value = 3;
        _getValueBehaviour = new OpenDependentGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (ComponentDoesNotContainTerminal(component))
            {
                return false;
            }
        }

        return true;
    }

    private static bool ComponentDoesNotContainTerminal(ICompleteHandComponent component)
    {
        foreach (Tile tile in component.GetTiles())
        {
            if (tile.IsTerminal())
            {
                return false;
            }
        }

        return true;
    }
}