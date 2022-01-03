using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class WhiteDragon : AbstractYaku
    {
        private int _counter;
        private List<TileObject> _handTiles;

        public WhiteDragon()
        {
            _name = "White Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForWhiteDragons();
            return AtLeastThreeWhiteDragons();
        }

        private void InitializeValues(AbstractHand hand, TileObject extraTile)
        {
            _counter = 0;
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool AtLeastThreeWhiteDragons()
        {
            return _counter >= 3;
        }

        private void CheckForWhiteDragons()
        {
            foreach (TileObject tile in _handTiles)
            {
                CheckIfWhiteDragon(tile);
            }
        }

        private void CheckIfWhiteDragon(TileObject tile)
        {
            if (IsTileWhiteDragon(tile))
            {
                _counter++;
            }
        }

        private bool IsTileWhiteDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.WHITE);
        }
    }
}
