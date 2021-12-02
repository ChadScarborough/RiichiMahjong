using RMU.Hand;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku.Yakuman
{
    public class BigThreeDragons : AbstractYakuman
    {
        private int _greenDragonCounter = 0;
        private int _redDragonCounter = 0;
        private int _whiteDragonCounter = 0;

        public BigThreeDragons()
        {
            _name = "Big Three Dragons";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            ResetCounters();
            foreach(TileObject tile in hand.Listify(extraTile))
            {
                if (CheckGreenDragon(tile)) continue;
                if (CheckRedDragon(tile)) continue;
                CheckWhiteDragon(tile);
            }
            return AtLeastThreeOfEachDragon();
        }

        private bool AtLeastThreeOfEachDragon()
        {
            bool greenDragons = _greenDragonCounter >= 3;
            bool redDragons = _redDragonCounter >= 3;
            bool whiteDragons = _whiteDragonCounter >= 3;
            return greenDragons && redDragons && whiteDragons;
        }

        private bool CheckGreenDragon(TileObject tile)
        {
            if (IsGreenDragon(tile))
            {
                _greenDragonCounter++;
                return true;
            }
            return false;
        }

        private bool CheckRedDragon(TileObject tile)
        {
            if (IsRedDragon(tile))
            {
                _redDragonCounter++;
                return true;
            }
            return false;
        }

        private void CheckWhiteDragon(TileObject tile)
        {
            if (IsWhiteDragon(tile))
            {
                _whiteDragonCounter++;
            }
        }

        private bool IsGreenDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.GREEN_DRAGON);
        }

        private bool IsRedDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.RED_DRAGON);
        }

        private bool IsWhiteDragon(TileObject tile)
        {
            return Functions.AreTilesEquivalent(tile, StandardTileList.WHITE_DRAGON);
        }

        private void ResetCounters()
        {
            _greenDragonCounter = 0;
            _redDragonCounter = 0;
            _whiteDragonCounter = 0;
        }
    }
}
