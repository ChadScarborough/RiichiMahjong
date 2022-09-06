using RMU.Wall;

namespace RMU.Games
{
    public class FourPlayerNoRedFivesGame : FourPlayerGame
    {
        public FourPlayerNoRedFivesGame()
        {
            _wallObject = new FourPlayerWallObjectNoRedFives();
        }
    }
}
