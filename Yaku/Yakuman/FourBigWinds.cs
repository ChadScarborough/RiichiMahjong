using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Yaku.Yakuman
{
    public class FourBigWinds : AbstractYakuman
    {
        private int _eastCounter;
        private int _southCounter;
        private int _westCounter;
        private int _northCounter;
        private List<TileObject> handTiles;

        public FourBigWinds()
        {
            _name = "Four Big Winds";
            _value = 26;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckTilesForWinds(hand, extraTile);
            return AreAtLeastThreeOfEachWind();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            ResetCounters();
            handTiles = hand.GetAllTiles(extraTile);
        }

        private void CheckTilesForWinds(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in handTiles)
            {
                CheckIfTileIsWindAndIncrementAppropriateCounter(tile);
            }
        }

        private bool AreAtLeastThreeOfEachWind()
        {
            return AreAtLeastThreeEasts() && AreAtLeastThreeSouths() && AreAtLeastThreeWests() && AreAtLeastThreeNorths();
        }

        private bool AreAtLeastThreeEasts()
        {
            return _eastCounter >= 3;
        }

        private bool AreAtLeastThreeSouths()
        {
            return _southCounter >= 3;
        }
        
        private bool AreAtLeastThreeWests()
        {
            return _westCounter >= 3;
        }

        private bool AreAtLeastThreeNorths()
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
            if (TileIsEastWind(tile))
            {
                _eastCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementedSouthCounterBecauseTileIsSouthWind(TileObject tile)
        {
            if (TileIsSouthWind(tile))
            {
                _southCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementedWestCounterBecauseTileIsWestWind(TileObject tile)
        {
            if (TileIsWestWind(tile))
            {
                _westCounter++;
                return true;
            }
            return false;
        }

        private void IncrementNorthCounterIfTileIsNorthWind(TileObject tile)
        {
            if (TileIsNorthWind(tile))
            {
                _northCounter++;
            }
        }

        private bool TileIsEastWind(TileObject tile)
        {
            return TileIsGivenWind(tile, Enums.EAST);
        }

        private bool TileIsSouthWind(TileObject tile)
        {
            return TileIsGivenWind(tile, Enums.SOUTH);
        }

        private bool TileIsWestWind(TileObject tile)
        {
            return TileIsGivenWind(tile, Enums.WEST);
        }

        private bool TileIsNorthWind(TileObject tile)
        {
            return TileIsGivenWind(tile, Enums.NORTH);
        }

        private bool TileIsGivenWind(TileObject tile, Enums.Wind wind)
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
