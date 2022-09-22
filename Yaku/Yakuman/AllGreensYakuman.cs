using System.Linq;
using RMU.Hands.CompleteHands;
using RMU.Tiles;

namespace RMU.Yaku.Yakuman;

public sealed class AllGreensYakuman : YakumanBase
{
    private readonly Tile[] _greenTiles =
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
        return _completeHand.GetTiles().All(IsGreenTile);
    }

    private bool IsGreenTile(Tile tile)
    {
        return _greenTiles.Any(t => AreTilesEquivalent(t, tile));
    }
}