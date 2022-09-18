using RMU.Hands.CompleteHands;
using RMU.Tiles;

namespace RMU.Yaku.Yakuman
{
    public class NineGatesYakuman : Yakuman
    {
        private readonly new StandardCompleteHand _completeHand;
        private readonly int[] _tileRequirements = { 3, 1, 1, 1, 1, 1, 1, 1, 3 };
        private int[] _tileCounts = new int[9];

        public NineGatesYakuman(ICompleteHand completeHand) : base(completeHand)
        {
            _name = "Nine Gates";
            _value = 13;
            _getValueBehaviour = new StandardGetValueBehaviour();
            _completeHand = completeHand as StandardCompleteHand;
        }

        public override bool Check()
        {
            if (_completeHand is null) return false;
            Suit suit = _completeHand.GetTiles()[0].GetSuit();
            foreach (Tile tile in _completeHand.GetTiles())
            {
                if (tile.GetSuit() != suit)
                    return false;
                int index = tile.GetValue() - 1;
                _tileCounts[index]++;
            }
            for(int i = 0; i < _tileRequirements.Length; i++)
            {
                if (_tileCounts[i] < _tileRequirements[i])
                    return false;
            }
            return true;
        }
    }
}
