using RMU.Calls.CallCommands;
using RMU.Games;
using RMU.Hands;
using RMU.Tiles;

namespace RMU.Players;

public abstract class ThreePlayerAbstractPlayer : Player
{

    protected ThreePlayerAbstractPlayer(Wind seatWind, Hand hand, AbstractGame game) : base(seatWind, hand, game)
    {

    }

    public void CallKita(Tile calledTile)
    {
        CallCommand callKita = new CallKitaCommand(this, calledTile);
        callKita.Execute();
    }
}