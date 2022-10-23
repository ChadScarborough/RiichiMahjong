using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;
using System.Linq;

namespace RMU.Yaku.StandardYaku;

internal sealed class YakuhaiYaku
{
    private readonly Tile _yakuhaiTile;
    private readonly StandardCompleteHand _completeHand;

    public YakuhaiYaku(ICompleteHand completeHand, Tile yakuhaiTile)
    {
        _yakuhaiTile = yakuhaiTile;
        _completeHand = completeHand as StandardCompleteHand;
    }

    public bool Check()
    {
        if (_completeHand?.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }

        List<ICompleteHandComponent> components = _completeHand.GetTriplets();
        return HandContainsTripletOfYakuhaiTileExcludingDrawTile(components);
    }

    private bool HandContainsTripletOfYakuhaiTileExcludingDrawTile(List<ICompleteHandComponent> components)
    {
        return components.Any(ComponentContainsYakuhaiTile);
    }

    private bool ComponentContainsYakuhaiTile(ICompleteHandComponent component)
    {
        return AreTilesEquivalent(component.GetLeadTile(), _yakuhaiTile);
    }
}