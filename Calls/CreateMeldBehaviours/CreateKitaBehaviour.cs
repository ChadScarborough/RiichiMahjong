using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateKitaBehaviour : ICreateMeldBehaviour
    {
        public List<Tile> CreateMeld(Tile calledTile)
        {
            if (Functions.AreWindsEquivalent(calledTile, Enums.NORTH))
            {
                return new List<Tile> { calledTile };
            }

            throw new Exception("Tried to create Kita with non-North tile");
        }
    }
}