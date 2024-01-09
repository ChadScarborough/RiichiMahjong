using RMU.Walls;

namespace RMU.Games;

public sealed class FourPlayerFourRedFivesGame : FourPlayerGame
{
    public FourPlayerFourRedFivesGame()
    {
        _wallObject ??= new FourPlayerWallObjectFourRedFives();
        Init();
    }
}
