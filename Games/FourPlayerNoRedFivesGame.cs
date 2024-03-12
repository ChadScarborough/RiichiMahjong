using Godot;
using RMU.Walls;

namespace RMU.Games;

public class FourPlayerNoRedFivesGame : FourPlayerGame
{
    public FourPlayerNoRedFivesGame()
    {
        GD.Print("FourPlayerNoRedFivesGame constructor called");
        _wallObject ??= new FourPlayerWallObjectNoRedFives();
        Init();
    }
}
