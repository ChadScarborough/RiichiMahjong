using System.Collections.Generic;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMU.Yaku.StandardYaku;

public class YakuhaiYaku
{
    private readonly TileObject _yakuhaiTile;
    private readonly StandardCompleteHand _completeHand;
    
    public YakuhaiYaku(ICompleteHand completeHand, TileObject yakuhaiTile)
    {
        _yakuhaiTile = yakuhaiTile;
        _completeHand = completeHand as StandardCompleteHand;
    }

    public bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD)
        {
            return false;
        }
        List<ICompleteHandComponent> components = _completeHand.GetTriplets();
        if (HandContainsTripletOfYakuhaiTileExcludingDrawTile(components))
        {
            return true;
        }

        return false;
    }

    private bool HandContainsTripletOfYakuhaiTileExcludingDrawTile(List<ICompleteHandComponent> components)
    {
        foreach (ICompleteHandComponent component in components)
        {
            if (ComponentContainsYakuhaiTile(component))
            {
                return true;
            }
        }

        return false;
    }

    private bool ComponentContainsYakuhaiTile(ICompleteHandComponent component)
    {
        return AreTilesEquivalent(component.GetLeadTile(), _yakuhaiTile);
    }
}