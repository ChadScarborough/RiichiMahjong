using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;
using RMU.Yaku.StrategyBehaviours;

namespace RMU.Yaku
{
    public class GreenDragon : AbstractYaku
    {
        private int _counter;
        private List<TileObject> _handTiles;

        public GreenDragon()
        {
            _name = "Green Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(AbstractHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForGreenDragons();
            return AtLeastThreeGreenDragons();
        }

        private void InitializeValues(AbstractHand hand, TileObject extraTile)
        {
            _counter = 0;
            _handTiles = hand.GetAllTiles(extraTile);
        }

        private bool AtLeastThreeGreenDragons()
        {
            return _counter >= 3;
        }

        private void CheckForGreenDragons()
        {
            foreach (TileObject tile in _handTiles)
            {
                CheckIfGreenDragon(tile);
            }
        }

        private void CheckIfGreenDragon(TileObject tile)
        {
            if (IsTileGreenDragon(tile))
            {
                _counter++;
            }
        }

        private bool IsTileGreenDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.GREEN);
        }
    }
}
