using RMU.Hand;
using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Yaku
{
    public class WhiteDragon : AbstractYaku
    {
        private int counter;
        private List<TileObject> tiles;

        public WhiteDragon()
        {
            _name = "White Dragon";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }
        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            InitializeValues(hand, extraTile);
            CheckForWhiteDragons();
            return AtLeastThreeWhiteDragons();
        }

        private void InitializeValues(IHand hand, TileObject extraTile)
        {
            counter = 0;
            tiles = hand.GetAllTiles(extraTile);
        }

        private bool AtLeastThreeWhiteDragons()
        {
            return counter >= 3;
        }

        private void CheckForWhiteDragons()
        {
            foreach (TileObject tile in tiles)
            {
                CheckIfWhiteDragon(tile);
            }
        }

        private void CheckIfWhiteDragon(TileObject tile)
        {
            if (IsTileWhiteDragon(tile))
            {
                counter++;
            }
        }

        private bool IsTileWhiteDragon(TileObject tile)
        {
            return Functions.AreDragonsEquivalent(tile, Enums.WHITE);
        }
    }
}
