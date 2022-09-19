using RMU.Walls;

namespace RMU.Games;

public sealed class FourPlayerNoRedFivesGame : FourPlayerGame
{
    public FourPlayerNoRedFivesGame() : base()
    {
        _wallObject = new FourPlayerWallObjectNoRedFives();
        Init();
    }
}
