using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Games;
using RMU.Hands;
using RMU.Players;
using RMU.TestObjects.TestHands;
using RMU.TestObjects.TestPlayers;
using RMU.Walls;

namespace RMU.TestObjects.TestGames;

public sealed class FourPlayerTestGame : FourPlayerGame
{
    public FourPlayerTestGame(Hand hand1, Hand hand2, Hand hand3, Hand hand4, WallObject wallObject)
    {
        _players = new FourPlayerAbstractPlayer[4];
        _wallObject = wallObject;
        _players[0] = new FourPlayerTestPlayer(EAST,  hand1, this);
        _players[1] = new FourPlayerTestPlayer(SOUTH, hand2, this);
        _players[2] = new FourPlayerTestPlayer(WEST,  hand3, this);
        _players[3] = new FourPlayerTestPlayer(NORTH, hand4, this);
        for (int i = 0; i < 4; i++)
        {
            TestHand h = _players[i].GetHand() as TestHand;
            h.SetWallObject(wallObject);
        }
        Init();
    }

    protected override void Init()
    {
        _players[0].SetPlayerID(0);
        _players[1].SetPlayerID(1);
        _players[2].SetPlayerID(2);
        _players[3].SetPlayerID(3);
        _wallObject.GenerateDeadWall();
        _wall = _wallObject.GetWall();
        _deadWall = _wallObject.GetDeadWall();
        ArrangePlayers();
        _firstGoAroundCounter = 4;
        Start();
    }

    protected override void Start()
    {
        _roundWind = EAST;
        _scoreObject = null;
        _activePlayer = GetEastPlayer();
        _winningCall = NO_WIN;
        _lastTile = null;
        _potentialQueue = new PriorityQueueForPotentialCalls();
        _commandQueue = new PriorityQueueForCallCommands(this);
        _visibleTiles = new Dictionary<(int, Suit), int>();
        foreach (Player player in _players)
        {
            player.SetPriorityQueueForPotentialCalls(_potentialQueue);
            player.SetPriorityQueueForCallCommands(_commandQueue);
            player.SetAvailablePotentialCalls();
        }
    }
}