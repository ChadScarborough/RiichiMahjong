using RMU.Walls;

namespace RMU.Games;

public sealed class FourPlayerNoRedFivesGame : FourPlayerGame
{
    public FourPlayerNoRedFivesGame()
    {
        _wallObject = new FourPlayerWallObjectNoRedFives();
        Init();
    }
}
