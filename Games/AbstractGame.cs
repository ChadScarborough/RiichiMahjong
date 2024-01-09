using System;
using System.Linq;
using Godot;
using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.DiscardPile;
using RMU.Games.Scoring;
using RMU.Hands;
using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Walls;
using RMU.Walls.DeadWall;
using RMU.Yaku;
using RMU.Yaku.StandardYaku;
using RMU.Yaku.Yakuman;

namespace RMU.Games;

public abstract class AbstractGame
{
    protected Player[] _players;
    protected WallObject _wallObject;
    protected Wall _wall;
    protected IDeadWall _deadWall;
    protected Tile _lastTile;
    protected PriorityQueueForPotentialCalls _potentialQueue;
    protected PriorityQueueForCallCommands _commandQueue;
    protected WinningCallType _winningCall;
    protected Player _activePlayer;
    protected Wind _roundWind;
    protected HandScoreBase _scoreObject;
    protected Dictionary<(int, Suit), int> _visibleTiles;

    protected int _firstGoAroundCounter;

    public event EventHandler onNewActivePlayer;
    public event EventHandler<HandScoreBase> onPlayerCalledRon;
    public event EventHandler<HandScoreBase> onPlayerCalledTsumo;

    protected virtual void Start()
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
        FillPlayerHands();
    }

    private void FillPlayerHands()
    {
        // Draw three sets of four each
        for(int j = 0; j < 3; j++)
        {
            foreach (Player p in _players)
            {
                for (int i = 0; i < 4; i++)
                {
                    p.DrawTile();
                }
            }
        }
        // Draw one more tile each
        foreach (Player p in _players)
        {
            p.DrawTile();
        }
        // Finish up
        foreach (Player p in _players)
        {
            if (p.GetSeatWind() is EAST)
            {
                p.DrawTile();
                continue;
            }
            p.GetHand().AddDrawTileToHand();
        }
    }

    internal bool IsFirstGoAround()
    {
        return _firstGoAroundCounter != 0;
    }

    internal void DecrementFirstGoAroundCounter()
    {
        if (_firstGoAroundCounter > 0)
            _firstGoAroundCounter--;
    }

    internal void CallWasMade()
    {
        _firstGoAroundCounter = 0;
    }
    
    public void SetDeadWall(IDeadWall deadWall)
    {
        _deadWall = deadWall;
        foreach (Player player in _players)
        {
            player.GetHand().SetDeadWall(deadWall);
        }
    }

    public void RotateWinds()
    {
        foreach (Player player in _players)
        {
            player.SetSeatWind(GetNewWind(player.GetSeatWind()));
        }
    }

    protected abstract Wind GetNewWind(Wind originalWind);

    public void CheckCalls()
    {
        foreach (Player player in _players)
        {
            if (player.IsActivePlayer() == false)
            {
                player.GeneratePotentialDiscardCalls(_lastTile);
                player.UpdateAvailableCalls();
            }
        }
        if (_potentialQueue.IsEmpty())
        {
            NextPlayer();
        }
    }

    public virtual void NextPlayer()
    {
        SetActivePlayer(_activePlayer.GetPlayerOnRight() ?? _activePlayer.GetPlayerAcross());
    }

    internal void SetActivePlayer(Player player)
    {
        _activePlayer = player;
        _activePlayer?.DrawTile();
        onNewActivePlayer?.Invoke(this, EventArgs.Empty);
    }

    internal void SetActivePlayerAfterCall(Player player)
    {
        _activePlayer = player;
        onNewActivePlayer?.Invoke(this, EventArgs.Empty);
    }

    public Player GetActivePlayer()
    {
        return _activePlayer;
    }

    public Player[] GetPlayers()
    {
        return _players;
    }

    public Player GetEastPlayer()
    {
        return GetPlayerByWind(EAST);
    }

    public Player GetSouthPlayer()
    {
        return GetPlayerByWind(SOUTH);
    }

    public Player GetWestPlayer()
    {
        return GetPlayerByWind(WEST);
    }

    public Player GetNorthPlayer()
    {
        return GetPlayerByWind(NORTH);
    }

    public Wall GetWall()
    {
        return _wall;
    }

    public IDeadWall GetDeadWall()
    {
        return _deadWall;
    }

    public WallObject GetWallObject()
    {
        return _wallObject;
    }

    public Tile GetLastTile()
    {
        return _lastTile;
    }

    public void SetLastTile(Tile tile)
    {
        _lastTile = tile;
    }

    public void ClearLastTile()
    {
        _lastTile = null;
    }

    private Player GetPlayerByWind(Wind wind)
    {
        return _players.FirstOrDefault(p => p.GetSeatWind() == wind);
    }

    public void CallTsumo(Player player, List<YakuBase> satisfiedYaku)
    {
        _winningCall = TSUMO;
        CallWin(player, satisfiedYaku);
        onPlayerCalledTsumo?.Invoke(this, _scoreObject);
    }

    public void CallRon(Player player, List<YakuBase> satisfiedYaku)
    {
        _winningCall = RON;
        CallWin(player, satisfiedYaku);
        onPlayerCalledRon?.Invoke(this, _scoreObject);
    }

    private void CallWin(Player player, List<YakuBase> satisfiedYaku)
    {
        if (satisfiedYaku.Count == 0)
        {
            throw new Exception("Hand completed with no satisfied yaku");
        }

        if (_winningCall == NO_WIN)
        {
            throw new Exception("No winning call made");
        }
        _scoreObject = satisfiedYaku[0].GetType().IsAssignableTo(typeof(YakumanBase)) ? 
            new YakumanHandScore(player, _winningCall) : 
            new StandardHandScore(player, _winningCall);
    }

    public HandScoreBase GetHandScore()
    {
        return _scoreObject;
    }

    public WinningCallType GetWinningCall()
    {
        return _winningCall;
    }

    public Wind GetRoundWind()
    {
        return _roundWind;
    }

    public void AddNewVisibleTile(Tile tile)
    {
        int value = tile.GetValue();
        Suit suit = tile.GetSuit();
        if (_visibleTiles.ContainsKey((value, suit)))
        {
            _visibleTiles[(value, suit)]++;
            return;
        }
        _visibleTiles.Add((value, suit), 1);
    }

    public int NumberOfCopiesVisible(Tile tile)
    {
        int value = tile.GetValue();
        Suit suit = tile.GetSuit();
        return _visibleTiles.ContainsKey((value, suit)) ? _visibleTiles[(value, suit)] : 0;
    }

    public void ExhaustiveDraw()
    {
        foreach (Player p in _players)
        {
            ICompleteHand h = new NullCompleteHand(p);
            YakuBase m = new ManganAtDrawYaku(h);
            if(m.Check())
                p.SetSatisfiedYaku(new List<YakuBase> { m });
        }
        // Exhaustive draw logic goes here
    }

    public void MakeDoraTiles()
    {
        Tile indicator = _deadWall.GetRevealedDoraIndicators()[^1];
        Tile doraTile = GetIndicatedDoraTile(indicator);
        MakeDoraTilesInCollection(_wall.GetWallTiles(), doraTile);

        foreach (Player p in _players)
        {
            Hand h = p.GetHand();
            MakeDoraTilesInCollection(h.GetAllTiles(), doraTile);
            IDiscardPile d = h.GetDiscardPile();
            MakeDoraTilesInCollection(d.GetDisplayedDiscardedTiles(), doraTile);
        }
    }
    
    private void MakeDoraTilesInCollection(List<Tile> collection, Tile doraTile)
    {
        foreach (Tile t in collection)
        {
            Tile tile = t;
            if (AreTilesEquivalent(doraTile, tile))
                AddDoraValue(ref tile);
        }
    }
}
