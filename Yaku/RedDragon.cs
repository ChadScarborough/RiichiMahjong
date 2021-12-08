using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class RedDragon : AbstractYaku
    {
        private int counter;
        private List<TileObject> tiles;

        public RedDragon()
        {
            _name = "Red Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForRedDragons();
            return AtLeastThreeRedDragons();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            counter = 0;
            tiles = hand.GetAllTiles(extraTile);
        }

        private bool AtLeastThreeRedDragons()
        {
            return counter >= 3;
        }

        private void CheckForRedDragons()
        {
            foreach (TileObject tile in tiles)
            {
                CheckIfRedDragon(tile);
            }
        }

        private void CheckIfRedDragon(TileObject tile)
        {
            if (IsTileRedDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileRedDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.RED);
        }
    }
}
