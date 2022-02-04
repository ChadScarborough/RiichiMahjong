using RMU.Hands.CompleteHands;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;

namespace RMU.Yaku.Yakuman;

public class AllGreensYakuman : Yakuman
{
    private readonly TileObject[] _greenTiles =
    {
        TWO_SOU,
        THREE_SOU,
        FOUR_SOU,
        SIX_SOU,
        EIGHT_SOU,
        GREEN_DRAGON
    };
    
    public AllGreensYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "All Greens";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        foreach (TileObject tile in _completeHand.GetTiles())
        {
            if (IsGreenTile(tile) == false) return false;
        }

        return true;
    }

    private bool IsGreenTile(TileObject tile)
    {
        foreach (TileObject t in _greenTiles)
        {
            if (AreTilesEquivalent(t, tile))
            {
                return true;
            }
        }

        return false;
    }
}