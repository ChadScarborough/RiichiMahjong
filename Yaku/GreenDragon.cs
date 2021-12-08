using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class GreenDragon : AbstractYaku
    {
        private int counter;
        private List<TileObject> tiles;

        public GreenDragon()
        {
            _name = "Green Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForGreenDragons();
            return AtLeastThreeGreenDragons();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            counter = 0;
            tiles = hand.Listify(extraTile);
        }

        private bool AtLeastThreeGreenDragons()
        {
            return counter >= 3;
        }

        private void CheckForGreenDragons()
        {
            foreach (TileObject tile in tiles)
            {
                CheckIfGreenDragon(tile);
            }
        }

        private void CheckIfGreenDragon(TileObject tile)
        {
            if (IsTileGreenDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileGreenDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.GREEN);
        }
    }
}
