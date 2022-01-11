using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreateKitaBehaviour : ICreateMeldBehaviour
    {
        public List<TileObject> CreateMeld(TileObject calledTile)
        {
            if (Functions.AreWindsEquivalent(calledTile, Enums.NORTH))
            {
                return new List<TileObject> { calledTile };
            }

            throw new Exception("Tried to create Kita with non-North tile");
        }
    }
}