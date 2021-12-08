using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Yaku
{
    public class FullFlush : AbstractYaku
    {
        private Enums.Suit _suit;
        private List<TileObject> _tiles;

        public FullFlush()
        {
            _name = "Full Flush";
            _value = 6;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            if (SuccessfullyFoundNonHonorTile() == false) return false;
            return AllSuitsAreTheSame();
        }

        private bool AllSuitsAreTheSame()
        {
            foreach (TileObject tile in _tiles)
            {
                if (SuitMatchesPrescribedSuit(tile)) continue;
                return false;
            }
            return true;
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            _hand = hand;
            _tiles = hand.Listify(extraTile);
        }

        private bool SuitMatchesPrescribedSuit(TileObject tile)
        {
            return tile.GetSuit() == _suit;
        }

        private bool SuccessfullyFoundNonHonorTile()
        {
            foreach(TileObject tile in _tiles)
            {
                if(tile.IsHonor() == false)
                {
                    SetSuit(tile);
                    return true;
                }
            }
            return false;
        }

        private void SetSuit(TileObject tile)
        {
            _suit = tile.GetSuit();
        }
    }
}
