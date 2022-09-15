using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;
using static RMU.Globals.Enums;

namespace RMU.Yaku.StandardYaku;

public class HalfOutsideHandYaku : YakuBase
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
        if (_completeHand.GetCompleteHandType() is THIRTEEN_ORPHANS) return false;

        foreach (ICompleteHandComponent component in _completeHand.GetConstructedHandComponents())
        {
            if (ComponentDoesNotContainTerminalOrHonor(component)) return false;
        }
        if (components[0].GetLeadTile().IsTerminal() == false) return false;
        if (components[^1].GetLeadTile().IsHonor() == false) return false;

        return true;
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