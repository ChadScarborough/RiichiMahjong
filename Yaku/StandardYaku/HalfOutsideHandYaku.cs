using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Yaku.StandardYaku;

public sealed class HalfOutsideHandYaku : YakuBase
{
    public HalfOutsideHandYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Half Outside Hand";
        _value = 2;
        _getValueBehaviour = new OpenDependentGetValueBehaviour();
    }

    public override bool Check()
    {
        List<ICompleteHandComponent> components = _completeHand.GetConstructedHandComponents();
        if (_completeHand.GetCompleteHandType() is THIRTEEN_ORPHANS)
        {
            return false;
        }

        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (ComponentDoesNotContainTerminalOrHonor(component))
            {
                return false;
            }
        }
        return components[0].GetLeadTile().IsTerminal() != false && components[^1].GetLeadTile().IsHonor() != false;
    }

    private bool ComponentDoesNotContainTerminalOrHonor(ICompleteHandComponent component)
    {
        foreach (Tile tile in component.GetTiles())
        {
            if (tile.IsTerminal() || tile.IsHonor())
            {
                return false;
            }
        }

        return true;
    }
}