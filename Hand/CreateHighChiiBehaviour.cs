using RMU.Tiles;
using RMU.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.Hand
{
    public class CreateHighChiiBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject _calledTile)
        {
            int value = _calledTile.GetValue();
            Enums.Suit suit = _calledTile.GetSuit();

            TileObject midTile = TileFactory.CreateTile(value + 1, suit);
            TileObject highTile = TileFactory.CreateTile(value + 2, suit);
            return new List<TileObject> { _calledTile, midTile, highTile };
        }
    }
}
