using RMU.Walls;

namespace RMU.Games;

public sealed class ThreePlayerNoRedFivesGame : ThreePlayerGame
{
    public ThreePlayerNoRedFivesGame()
    {
        _wallObject ??= new ThreePlayerWallObjectNoRedFives();
        Init();
    }
}
