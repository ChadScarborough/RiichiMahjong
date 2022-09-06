using RMU.Wall;

namespace RMU.Games
{
    public class FourPlayerNoRedFivesGame : FourPlayerGame
    {
        public FourPlayerNoRedFivesGame() : base()
        {
            _wallObject = new FourPlayerWallObjectNoRedFives();
            base.Init();
        }
    }
}
