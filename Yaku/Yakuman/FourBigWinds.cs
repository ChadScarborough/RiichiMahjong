using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku.Yakuman
{
    public class FourBigWinds : AbstractYakuman
    {
        private int _eastCounter;
        private int _southCounter;
        private int _westCounter;
        private int _northCounter;

        public FourBigWinds()
        {
            _name = "Four Big Winds";
            _value = 26;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            ResetCounters();
            CheckTilesForWinds(hand, extraTile);
            return AreAtLeastThreeOfEachWind();
        }

        private void CheckTilesForWinds(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                CheckIfTileIsWindAndIncrementAppropriateCounter(tile);
            }
        }

        private bool AreAtLeastThreeOfEachWind()
        {
            return AreAtLeastThreeEast() && AreAtLeastThreeSouth() && AreAtLeastThreeWest() && AreAtLeastThreeNorth();
        }

        private bool AreAtLeastThreeEast()
        {
            return _eastCounter >= 3;
        }

        private bool AreAtLeastThreeSouth()
        {
            return _southCounter >= 3;
        }
        
        private bool AreAtLeastThreeWest()
        {
            return _westCounter >= 3;
        }

        private bool AreAtLeastThreeNorth()
        {
            return _northCounter >= 3;
        }

        private void CheckIfTileIsWindAndIncrementAppropriateCounter(TileObject tile)
        {
            if (IncrementedEastCounterBecauseTileIsEastWind(tile)) return;
            if (IncrementedSouthCounterBecauseTileIsSouthWind(tile)) return;
            if (IncrementedWestCounterBecauseTileIsWestWind(tile)) return;
            IncrementNorthCounterIfTileIsNorthWind(tile);
        }

        private bool IncrementedEastCounterBecauseTileIsEastWind(TileObject tile)
        {
            if (IsEastWind(tile))
            {
                _eastCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementedSouthCounterBecauseTileIsSouthWind(TileObject tile)
        {
            if (IsSouthWind(tile))
            {
                _southCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementedWestCounterBecauseTileIsWestWind(TileObject tile)
        {
            if (IsWestWind(tile))
            {
                _westCounter++;
                return true;
            }
            return false;
        }

        private void IncrementNorthCounterIfTileIsNorthWind(TileObject tile)
        {
            if (IsNorthWind(tile))
            {
                _northCounter++;
            }
        }

        private bool IsEastWind(TileObject tile)
        {
            return IsGivenWind(tile, Enums.EAST);
        }

        private bool IsSouthWind(TileObject tile)
        {
            return IsGivenWind(tile, Enums.SOUTH);
        }

        private bool IsWestWind(TileObject tile)
        {
            return IsGivenWind(tile, Enums.WEST);
        }

        private bool IsNorthWind(TileObject tile)
        {
            return IsGivenWind(tile, Enums.NORTH);
        }

        private bool IsGivenWind(TileObject tile, Enums.Wind wind)
        {
            return Functions.AreWindsEquivalent(tile, wind);
        }

        private void ResetCounters()
        {
            _eastCounter = 0;
            _southCounter = 0;
            _westCounter = 0;
            _northCounter = 0;
        }
    }
}
