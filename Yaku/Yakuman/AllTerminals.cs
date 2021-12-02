using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku.Yakuman
{
    public class AllTerminals : AbstractYakuman
    {
        public AllTerminals()
        {
            _name = "All Terminals";
            _value = 13;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                if (tile.IsTerminal() == false)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
