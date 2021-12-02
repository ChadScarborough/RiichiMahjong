using RMU.Tiles;
using System.Collections.Generic;
using RMU.Globals;

namespace RMU.Hand
{
    public class CreateMidChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile)
        {
            int value = _calledTile.GetValue();
            Enums.Suit suit = _calledTile.GetSuit();

            TileObject lowTile = TileFactory.CreateTile(value - 1, suit);
            TileObject highTile = TileFactory.CreateTile(value + 1, suit);
            return new List<TileObject> { lowTile, _calledTile, highTile };
        }
    }
}
