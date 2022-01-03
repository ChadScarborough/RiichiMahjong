using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class HalfFlush : AbstractYaku
    {
        private Enums.Suit _prescribedSuit;
        private List<TileObject> _handTiles;

        public HalfFlush()
        {
            _name = "Half Flush";
            _value = 3;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeHandTiles(hand, extraTile);
            if (HandDoesNotContainBothHonorsAndNonHonors()) return false;
            return EveryTileIsSameSuitOrHonor();
        }

        private bool HandDoesNotContainBothHonorsAndNonHonors()
        {
            return HandContainsHonorsAndNonHonors() == false;
        }

        private void InitializeHandTiles(AbstractHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool EveryTileIsSameSuitOrHonor()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileMatchesPrescribedSuitOrIsHonorTile(tile)) continue;
                return false;
            }
            return true;
        }

        private bool TileMatchesPrescribedSuitOrIsHonorTile(TileObject tile)
        {
            return TileSuitMatchesPrescribedSuit(tile) || TileIsHonorTile(tile);
        }

        private bool TileSuitMatchesPrescribedSuit(TileObject tile)
        {
            return tile.GetSuit() == _prescribedSuit;
        }

        private bool HandContainsHonorsAndNonHonors()
        {
            return SuccessfullyFoundHonorTile() && SuccessfullyFoundNonHonorTileAndSetPrescribedSuit();
        }

        private bool SuccessfullyFoundNonHonorTileAndSetPrescribedSuit()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsNonHonorTile(tile))
                {
                    SetPrescribedSuit(tile);
                    return true;
                }
            }
            return false;
        }

        private static bool TileIsNonHonorTile(TileObject tile)
        {
            return tile.IsHonor() == false;
        }

        private void SetPrescribedSuit(TileObject tile)
        {
            _prescribedSuit = tile.GetSuit();
        }

        private bool SuccessfullyFoundHonorTile()
        {
            foreach(TileObject tile in _handTiles)
            {
                if (TileIsHonorTile(tile))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool TileIsHonorTile(TileObject tile)
        {
            return tile.IsHonor();
        }
    }
}
