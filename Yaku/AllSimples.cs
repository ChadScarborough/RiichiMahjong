using RMU.Hand;
using RMU.Tiles;

namespace RMU.Yaku
{
    public class AllSimples : AbstractYaku
    {

        public AllSimples()
        {
            _name = "All Simples";
            _value = 1;
            _getNameBehaviour = new StandardGetNameBehaviour();
            _getValueBehaviour = new StandardGetValueBehaviour();
        }

        public override bool CheckYaku(IHand hand, TileObject extraTile)
        {
            foreach (TileObject tile in hand.Listify(extraTile))
            {
                if (tile.IsHonor() || tile.IsTerminal())
                {
                    return false;
                }
            }
            return true;
        }
    }
}
