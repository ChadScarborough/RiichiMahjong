using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Yaku.Yakuman
{
    public class AllGreens : AbstractYakuman
    {
        List<TileObject> _handTiles;
        List<TileObject> _greenTileList = new List<TileObject>
        {
            StandardTileList.TwoSou(),
            StandardTileList.ThreeSou(),
            StandardTileList.FourSou(),
            StandardTileList.SixSou(),
            StandardTileList.EightSou(),
            StandardTileList.GreenDragon()
        };

        public AllGreens()
        {
            _name = "All Greens";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeHand(hand, extraTile);
            return AllTilesInHandAreGreen();
        }

        private void InitializeHand(IHand hand, TileObject extraTile)
        {
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool AllTilesInHandAreGreen()
        {
            foreach (TileObject tile in _handTiles)
            {
                if (TileIsNotGreen(tile))
                {
                    return false;
                }
            }
            return true;
        }

        private bool TileIsNotGreen(TileObject tile)
        {
            return ListContainsTile(tile, _greenTileList) == false;
        }

        private bool ListContainsTile(TileObject tile, List<TileObject> list)
        {
            foreach(TileObject listTile in list)
            {
                if (Functions.AreTilesEquivalent(tile, listTile)) return true;
            }
            return false;
        }
    }
}
