using RMU.Wall;

namespace RMU.Games
{
    public class ThreePlayerTwoRedFivesGame : ThreePlayerGame
    {
        public ThreePlayerTwoRedFivesGame()
        {
            _wallObject = new ThreePlayerWallObjectTwoRedFives();
        }
    }
}
