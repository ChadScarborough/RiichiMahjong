using RMU.Wall;

namespace RMU.Games;

public sealed class FourPlayerFourRedFivesGame : FourPlayerGame
{
    public FourPlayerFourRedFivesGame()
    {
        _wallObject = new FourPlayerWallObjectFourRedFives();
        Init();
    }
}
