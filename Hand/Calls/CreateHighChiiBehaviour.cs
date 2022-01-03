using RMU.Tiles;
using RMU.Globals;
using System.Collections.Generic;

namespace RMU.Hand.Calls
{
    public class CreateHighChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            int value = calledTile.GetValue();
            Enums.Suit suit = calledTile.GetSuit();

            TileObject midTile = TileFactory.CreateTile(value + 1, suit);
            TileObject highTile = TileFactory.CreateTile(value + 2, suit);
            return new List<TileObject> { calledTile, midTile, highTile };
        }
    }
}
