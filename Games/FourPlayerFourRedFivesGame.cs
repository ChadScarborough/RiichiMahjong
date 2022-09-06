using RMU.Wall;

namespace RMU.Games
{
    public class FourPlayerFourRedFivesGame : FourPlayerGame
    {
        public FourPlayerFourRedFivesGame()
        {
            _wallObject = new FourPlayerWallObjectFourRedFives();
        }
    }
}
