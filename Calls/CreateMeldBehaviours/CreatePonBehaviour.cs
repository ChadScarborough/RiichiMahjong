using System.Collections.Generic;
using RMU.Tiles;

namespace RMU.Calls.CreateMeldBehaviours
{
    public class CreatePonBehaviour : ICreateMeldBehaviour
    {
        public List<Tile> CreateMeld(Tile calledTile)
        {
            return new List<Tile>
            {
                calledTile.Clone(), 
                calledTile.Clone(), 
                calledTile.Clone()
            };
        }
    }
}
