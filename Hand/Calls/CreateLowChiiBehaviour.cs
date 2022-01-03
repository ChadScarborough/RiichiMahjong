using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Hand.Calls
{
    public class CreateLowChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            int value = calledTile.GetValue();
            Enums.Suit suit = calledTile.GetSuit();

            TileObject lowTile = TileFactory.CreateTile(value - 2, suit);
            TileObject midTile = TileFactory.CreateTile(value - 1, suit);
            return new List<TileObject> { lowTile, midTile, calledTile };
        }
    }
}
