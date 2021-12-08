using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Yaku
{
    public class HalfFlush : AbstractYaku
    {
        private Enums.Suit _suit;
        private List<TileObject> _tiles;

        public HalfFlush()
        {
            _name = "Half Flush";
            _value = 3;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new OpenDependentGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            if (HandContainsHonorsAndNonHonors() == false) return false;
            return EveryTileIsSameSuitOrHonor();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            _hand = hand;
            _tiles = hand.GetAllTiles(extraTile);
        }

        private bool EveryTileIsSameSuitOrHonor()
        {
            foreach (TileObject tile in _tiles)
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

        private static bool TileIsHonorTile(TileObject tile)
        {
            return tile.IsHonor();
        }

        private bool TileSuitMatchesPrescribedSuit(TileObject tile)
        {
            return tile.GetSuit() == _suit;
        }

        private bool HandContainsHonorsAndNonHonors()
        {
            return SuccessfullyFoundHonorTile() && SuccessfullyFoundNonHonorTileAndSetPrescribedSuit();
        }

        private bool SuccessfullyFoundNonHonorTileAndSetPrescribedSuit()
        {
            foreach (TileObject tile in _tiles)
            {
                if (tile.IsHonor() == false)
                {
                    SetPrescribedNonHonorSuit(tile);
                    return true;
                }
            }
            return false;
        }

        private void SetPrescribedNonHonorSuit(TileObject tile)
        {
            _suit = tile.GetSuit();
        }

        private bool SuccessfullyFoundHonorTile()
        {
            foreach(TileObject tile in _tiles)
            {
                if (tile.IsHonor())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
