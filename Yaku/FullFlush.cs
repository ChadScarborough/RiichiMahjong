using RMU.Hand;
using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class FullFlush : AbstractYaku
    {
        private Enums.Suit _prescribedSuit;
        private List<TileObject> _handTiles;

        public FullFlush()
        {
            _name = "Full Flush";
            _value = 6;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeHandTiles(hand, extraTile);
            if (DidNotFindNonHonorTileForPrescribedSuit()) return false;
            return AllSuitsAreTheSame();
        }

        private bool DidNotFindNonHonorTileForPrescribedSuit()
        {
            return SuccessfullyFoundNonHonorTileAndSetPrescribedSuit() == false;
        }

        private bool AllSuitsAreTheSame()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (SuitDoesNotMatchPrescribedSuit(tile)) return false;
            }
            return true;
        }

        private bool SuitDoesNotMatchPrescribedSuit(TileObject tile)
        {
            return SuitMatchesPrescribedSuit(tile) == false;
        }

        private void InitializeHandTiles(AbstractHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool SuitMatchesPrescribedSuit(TileObject tile)
        {
            return tile.GetSuit() == _prescribedSuit;
        }

        private bool SuccessfullyFoundNonHonorTileAndSetPrescribedSuit()
        {
            foreach(TileObject tile in _handTiles)
            {
                if (TileIsNotHonor(tile))
                {
                    SetPrescribedSuit(tile);
                    return true;
                }
            }
            return false;
        }

        private static bool TileIsNotHonor(TileObject tile)
        {
            return tile.IsHonor() == false;
        }

        private void SetPrescribedSuit(TileObject tile)
        {
            _prescribedSuit = tile.GetSuit();
        }
    }
}
