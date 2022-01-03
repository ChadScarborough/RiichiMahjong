using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class RedDragon : AbstractYaku
    {
        private int _counter;
        private List<TileObject> _handTiles;

        public RedDragon()
        {
            _name = "Red Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForRedDragons();
            return AtLeastThreeRedDragons();
        }

        private void InitializeValues(AbstractHand hand, TileObject extraTile)
        {
            _counter = 0;
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool AtLeastThreeRedDragons()
        {
            return _counter >= 3;
        }

        private void CheckForRedDragons()
        {
            foreach (TileObject tile in _handTiles)
            {
                CheckIfRedDragon(tile);
            }
        }

        private void CheckIfRedDragon(TileObject tile)
        {
            if (IsTileRedDragon(tile))
            {
                _counter++;
            }
        }

        private bool IsTileRedDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.RED);
        }
    }
}
