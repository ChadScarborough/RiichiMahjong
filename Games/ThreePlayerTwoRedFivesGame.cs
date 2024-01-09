using RMU.Walls;

namespace RMU.Games;

public sealed class ThreePlayerTwoRedFivesGame : ThreePlayerGame
{
    public ThreePlayerTwoRedFivesGame()
    {
        _wallObject ??= new ThreePlayerWallObjectTwoRedFives();
        Init();
    }
}
