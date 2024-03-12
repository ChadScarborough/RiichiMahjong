using RMU.Walls;

namespace RMU.Games;

public sealed class FourPlayerThreeRedFivesGame : FourPlayerGame
{
    public FourPlayerThreeRedFivesGame()
    {
        _wallObject ??= new FourPlayerWallObjectThreeRedFives();
        Init();
    }
}
