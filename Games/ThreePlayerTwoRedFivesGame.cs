using RMU.Wall;

namespace RMU.Games;

public sealed class ThreePlayerTwoRedFivesGame : ThreePlayerGame
{
    public ThreePlayerTwoRedFivesGame()
    {
        _wallObject = new ThreePlayerWallObjectTwoRedFives();
        Init();
    }
}
