using RMU.Wall;

namespace RMU.Games;

public sealed class FourPlayerThreeRedFivesGame : FourPlayerGame
{
    public FourPlayerThreeRedFivesGame()
    {
        _wallObject = new FourPlayerWallObjectThreeRedFives();
        Init();
    }
}
