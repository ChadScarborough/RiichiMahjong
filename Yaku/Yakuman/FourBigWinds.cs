using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

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
            foreach(TileObject tile in hand.Listify(extraTile))
            {
                CheckTile(tile);
            }
            return AreAtLeastThreeOfEachWind();
        }

        private bool AreAtLeastThreeOfEachWind()
        {
            bool atLeastThreeEast = _eastCounter >= 3;
            bool atLeastThreeSouth = _southCounter >= 3;
            bool atLeastThreeWest = _westCounter >= 3;
            bool atLeastThreeNorth = _northCounter >= 3;
            return atLeastThreeEast && atLeastThreeSouth && atLeastThreeWest && atLeastThreeNorth;
        }

        private void CheckTile(TileObject tile)
        {
            if (IncrementEastCounterIfTileIsEastWind(tile)) return;
            if (IncrementSouthCounterIfTileIsSouthWind(tile)) return;
            if (IncrementWestCounterIfTileIsWestWind(tile)) return;
            IncrementNorthCounterIfTileIsNorthWind(tile);
        }

        private bool IncrementEastCounterIfTileIsEastWind(TileObject tile)
        {
            if (IsEastWind(tile))
            {
                _eastCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementSouthCounterIfTileIsSouthWind(TileObject tile)
        {
            if (IsSouthWind(tile))
            {
                _southCounter++;
                return true;
            }
            return false;
        }

        private bool IncrementWestCounterIfTileIsWestWind(TileObject tile)
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
            return Functions.AreTilesEquivalent(tile, StandardTileList.EAST_WIND);
        }

        private bool IsSouthWind(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.SOUTH_WIND);
        }

        private bool IsWestWind(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.WEST_WIND);
        }

        private bool IsNorthWind(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.NORTH_WIND);
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
