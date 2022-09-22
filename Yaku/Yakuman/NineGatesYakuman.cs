using System.Linq;
using RMU.Hands.CompleteHands;
using RMU.Tiles;

namespace RMU.Yaku.Yakuman;

public sealed class NineGatesYakuman : YakumanBase
{
    private new readonly StandardCompleteHand _completeHand;
    private readonly int[] _tileRequirements = { 3, 1, 1, 1, 1, 1, 1, 1, 3 };
    private readonly int[] _tileCounts = new int[9];

    public NineGatesYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Nine Gates";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
        _completeHand = completeHand as StandardCompleteHand;
    }

    public override bool Check()
    {
        if (_completeHand is null)
        {
            return false;
        }

        Suit suit = _completeHand.GetTiles()[0].GetSuit();
        foreach (Tile tile in _completeHand.GetTiles())
        {
            if (tile.GetSuit() != suit)
            {
                return false;
            }

            int index = tile.GetValue() - 1;
            _tileCounts[index]++;
        }

        return !_tileRequirements.Where((t, i) => _tileCounts[i] < t).Any();
    }
}
