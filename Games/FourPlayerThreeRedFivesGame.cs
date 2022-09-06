using RMU.Wall;

namespace RMU.Games
{
    public class FourPlayerThreeRedFivesGame : FourPlayerGame
    {
        public FourPlayerThreeRedFivesGame()
        {
            _wallObject = new FourPlayerWallObjectThreeRedFives();
            base.Init();
        }
    }
}
