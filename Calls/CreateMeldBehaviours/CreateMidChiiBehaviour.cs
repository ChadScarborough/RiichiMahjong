using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateMidChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            int value = calledTile.GetValue();
            Enums.Suit suit = calledTile.GetSuit();

            TileObject lowTile = TileFactory.CreateTile(value - 1, suit);
            TileObject highTile = TileFactory.CreateTile(value + 1, suit);
            return new List<TileObject> { lowTile, calledTile, highTile };
        }
    }
}
