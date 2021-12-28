using System.Collections.Generic;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Wall
{
    public class StandardWall_ThreeRedFives : StandardWall
    {
        public StandardWall_ThreeRedFives()
        {
            PopulateWall();
        }

        protected override void GenerateTilesOfAGivenSuitAndNumber(Enums.Suit suit, int numberOfValues, List<TileObject> destination)
        {
            for (int i = 0; i < numberOfValues; i++)
            {
                for (int j = 0; j < NUMBER_OF_COPIES; j++)
                {
                    TileObject _tile = TileFactory.CreateTile(i + 1, suit);
                    if(i == 4 && j == 0)
                    {
                        Functions.MakeRedFive(ref _tile);
                    }
                    destination.Add(_tile);
                }
            }
        }
    }
}
