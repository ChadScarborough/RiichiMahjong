using RMU.Wall;

namespace RMU.Games
{
    public class ThreePlayerNoRedFivesGame : ThreePlayerGame
    {
        public ThreePlayerNoRedFivesGame()
        {
            _wallObject = new ThreePlayerWallObjectNoRedFives();
            base.Init();
        }
    }
}
