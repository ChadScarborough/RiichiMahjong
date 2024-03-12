using RMU.Games;
using RMU.Hands;
using RMU.Yaku;

namespace RMU.Players;

public abstract partial class Player
{
    protected Player(Wind seatWind, Hand hand, AbstractGame game)
    {
        _seatWind = seatWind;
        _hand = hand;
        _game = game;
        _satisfiedYaku = new List<YakuBase>();
        _closedKanTiles = null;
        SetAvailablePotentialCalls();
    }

    public void FirstTurn()
    {
        NegateCalls();
        CheckForOpenKan2();
        CheckForClosedKan();
        CheckForTsumo();
    }
}