using RMU.Wall;

namespace RMU.Games;

public sealed class ThreePlayerNoRedFivesGame : ThreePlayerGame
{
    public ThreePlayerNoRedFivesGame()
    {
        _wallObject = new ThreePlayerWallObjectNoRedFives();
        Init();
    }
}
