using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Games;
using RMU.Hands;
using RMU.Hands.CompleteHands;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using RMU.Yaku;
using System;
using System.Linq;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players;

public abstract class Player
{
    private Wind _seatWind;
    private readonly Hand _hand;
    private Player _playerOnLeft;
    private Player _playerAcross;
    private Player _playerOnRight;
    private int _score;
    private readonly AbstractGame _game;
    protected PriorityQueueForPotentialCalls _priorityQueueForPotentialCalls;
    private PriorityQueueForCallCommands _priorityQueueForCallCommands;
    protected AvailablePotentialCalls _availablePotentialCalls;
    private ICompleteHand _completeHand;
    private List<YakuBase> _satisfiedYaku;

    private Tile? _closedKanTile;

    private bool _canPon;
    private bool _canOpenKan1;
    private bool _canRon;
    private bool _canTsumo;
    private bool _canClosedKan;

    private int _playerID;

    public event EventHandler OnHandChanged;
    public event EventHandler OnShantenUpdated;
    public event EventHandler OnCanPon;
    public event EventHandler OnCanHighChii;
    public event EventHandler OnCanMidChii;
    public event EventHandler OnCanLowChii;
    public event EventHandler OnCanRon;
    public event EventHandler OnCanTsumo;

    protected Player(Wind seatWind, Hand hand, AbstractGame game)
    {
        _seatWind = seatWind;
        _hand = hand;
        _game = game;
        _satisfiedYaku = new List<YakuBase>();
        _closedKanTile = null;
        SetAvailablePotentialCalls();
    }

#region GettersAndSetters
    public int GetPlayerID()
    {
        return _playerID;
    }

    public void SetPlayerID(int id)
    {
        _playerID = id;
    }

    public AbstractGame GetGame()
    {
        return _game;
    }

    public virtual bool IsActivePlayer()
    {
        return _game.GetActivePlayer().Equals(this);
    }

    public Hand GetHand()
    {
        return _hand;
    }

    public Wind GetSeatWind()
    {
        return _seatWind;
    }

    public void SetSeatWind(Wind seatWind)
    {
        _seatWind = seatWind;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetPlayerOnLeft(Player player)
    {
        CheckForDuplicatePlayers(player, GetPlayerAcross(), GetPlayerOnRight());
        CheckThatThisPlayerIsNotDuplicated(player);
        _playerOnLeft = player;
    }

    public void SetPlayerAcross(Player player)
    {
        CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerOnRight());
        CheckThatThisPlayerIsNotDuplicated(player);
        _playerAcross = player;
    }

    public void SetPlayerOnRight(Player player)
    {
        CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerAcross());
        CheckThatThisPlayerIsNotDuplicated(player);
        _playerOnRight = player;
    }

    public Player GetPlayerOnLeft()
    {
        return _playerOnLeft;
    }

    public Player GetPlayerAcross()
    {
        return _playerAcross;
    }

    public Player GetPlayerOnRight()
    {
        return _playerOnRight;
    }

    public override string ToString()
    {
        return $"Player { _playerID }";
    }
#endregion

#region DrawAndDiscard
    public void Discard(int index)
    {
        if (!IsActivePlayer()) return;
        NegateCalls();
        Tile tile = _hand.GetClosedTiles()[index].Clone();
        _hand.DiscardTile(index);
        _game.SetLastTile(tile);
        _game.CheckCalls();
        _game.DecrementFirstGoAroundCounter();
        OnHandChanged?.Invoke(this, EventArgs.Empty);
        OnShantenUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void DiscardDrawTile()
    {
        if (!IsActivePlayer()) return;
        NegateCalls();
        Tile tile = _hand.GetDrawTile().Clone();
        _hand.DiscardDrawTile();
        _game.SetLastTile(tile);
        _game.CheckCalls();
        _game.DecrementFirstGoAroundCounter();
        OnHandChanged?.Invoke(this, EventArgs.Empty);
        OnShantenUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void DrawTile()
    {
        // if (_game.GetWall().GetSize() == 0)
        // {
        //     _game.ExhaustiveDraw();
        //     return;
        // }
        _hand.DrawTileFromWall();
        CheckForTsumo();
        CheckForClosedKan();
        OnHandChanged?.Invoke(this, EventArgs.Empty);
        OnShantenUpdated?.Invoke(this, EventArgs.Empty);
    }

    public void DrawTileFromDeadWall()
    {
        _hand.DrawTileFromDeadWall();
        CheckForTsumo();
        CheckForClosedKan();
        OnHandChanged?.Invoke(this, EventArgs.Empty);
        OnShantenUpdated?.Invoke(this, EventArgs.Empty);
    }

#endregion

#region Calls
    private void NegateCalls()
    {
        _canPon = false;
        _canRon = false;
        _canTsumo = false;
        _canClosedKan = false;
        _canOpenKan1 = false;
    }
    
    protected void InvokeOnCanHighChii()
    {
        OnCanHighChii?.Invoke(this, EventArgs.Empty);
    }

    protected void InvokeOnCanMidChii()
    {
        OnCanMidChii?.Invoke(this, EventArgs.Empty);
    }

    protected void InvokeOnCanLowChii()
    {
        OnCanLowChii?.Invoke(this, EventArgs.Empty);
    }

    public void SetAvailablePotentialCalls()
    {
        _availablePotentialCalls = new AvailablePotentialCalls(this, _priorityQueueForPotentialCalls);
    }

    public void SetPriorityQueueForPotentialCalls(PriorityQueueForPotentialCalls queue)
    {
        _priorityQueueForPotentialCalls = queue;
    }

    public void SetPriorityQueueForCallCommands(PriorityQueueForCallCommands queue)
    {
        _priorityQueueForCallCommands = queue;
    }

    public void CancelCalls()
    {
        _priorityQueueForPotentialCalls.RemoveByPlayer(this);
        NegateCalls();
        UpdateAvailableCalls();
        if (_priorityQueueForPotentialCalls.IsEmpty())
        {
            _priorityQueueForCallCommands.Execute();
        }
    }

    protected void MakeCall(CallCommand command)
    {
        _priorityQueueForPotentialCalls.RemoveByPlayer(this);
        _priorityQueueForPotentialCalls.RemoveByPriority(command.GetPriority());
        _priorityQueueForCallCommands.AddCall(command);
        if (_priorityQueueForPotentialCalls.IsEmpty())
        {
            _priorityQueueForCallCommands.Execute();
        }
        OnHandChanged?.Invoke(this, EventArgs.Empty);
        NegateCalls();
        _game.SetActivePlayerAfterCall(this);
    }

    public bool CanPon()
    {
        return _canPon;
    }

    public bool CanClosedKan()
    {
        return _canClosedKan;
    }

    public bool CanOpenKan1()
    {
        return _canOpenKan1;
    }

    public bool CanRon()
    {
        return _canRon;
    }

    public bool CanTsumo()
    {
        if (IsActivePlayer() == false)
            return false;
        return _canTsumo;
    }

    public void CallPon(Tile calledTile)
    {
        UpdateAvailableCalls();
        if (_canPon)
        {
            CallCommand callPon = new CallPonCommand(this, calledTile);
            MakeCall(callPon);
            UpdateAvailableCalls();
        }
    }

    public void CallClosedKan()
    {
        if (_canClosedKan == false) return;
        if (IsActivePlayer() == false) return;
        CallCommand callClosedKan = new CallClosedKanCommand(this, _closedKanTile);
        callClosedKan.Execute();
        _game.MakeDoraTiles();
        _canClosedKan = false;
        UpdateAvailableCalls();
        OnHandChanged?.Invoke(this, EventArgs.Empty);
    }

    public void CallOpenKan1(Tile calledTile)
    {
        UpdateAvailableCalls();
        if (_canOpenKan1)
        {
            CallCommand callOpenKan1 = new CallOpenKan1Command(this, calledTile);
            MakeCall(callOpenKan1);
            UpdateAvailableCalls();
        }
    }

    public void CallOpenKan2(Tile calledTile)
    {
        CallCommand callOpenKan2 = new CallOpenKan2Command(this, calledTile);
        callOpenKan2.Execute();
        UpdateAvailableCalls();
    }

    public void CallRon()
    {
        Tile calledTile = _game.GetLastTile();
        UpdateAvailableCalls();
        if (!_canRon) return;
        CallCommand callRon = new CallRonCommand(this, calledTile);
        MakeCall(callRon);
    }

    public void CallTsumo()
    {
        if (_canTsumo == false)
        {
            return;
        }

        _game.CallTsumo(this, _satisfiedYaku);
    }

    public virtual void GeneratePotentialDiscardCalls(Tile lastTile)
    {
        if (IsActivePlayer())
            return;
        GeneratePotentialPonAndKanCalls(this, _priorityQueueForPotentialCalls, lastTile);
        GeneratePotentialRonCall(this, _priorityQueueForPotentialCalls, lastTile);
    }

    public virtual void UpdateAvailableCalls()
    {
        _availablePotentialCalls.UpdateAvailableCalls();
        _canPon = _availablePotentialCalls.CanCallPon();
        if (_canPon)
            OnCanPon?.Invoke(this, EventArgs.Empty);
        _canOpenKan1 = _availablePotentialCalls.CanCallOpenKan1();
        _canRon = _availablePotentialCalls.CanCallRon();
        if (_canRon)
            OnCanRon?.Invoke(this, EventArgs.Empty);
    }

    private void CheckForClosedKan()
    {
        int count = 0;
        Tile? tile = null;
        foreach (Tile t in _hand.GetTilesInHand())
        {
            tile = CountCopiesOfTile(tile, t, ref count);

            if (count != 4) continue;
            _canClosedKan = true;
            _closedKanTile = tile;
            return;
        }
        // Modify to make multiple kan calls possible
        _canClosedKan = false;
        _closedKanTile = null;
    }
#endregion

#region HandCompletion
    private void CheckForTsumo()
    {
        InitializeValuesForTsumoCheck();
        if (IsActivePlayer() is false)
        {
            return;
        }

        if (_hand.GetShanten() > -1)
        {
            return;
        }

        List<ICompleteHand> completeHands = GetAllCompleteHandsForTsumoCheck();
        if (completeHands.Count == 0)
        {
            Console.WriteLine("No complete hands constructed");
            return;
        }

        _canTsumo = AtLeastOneYakuSatisfied(completeHands);

        if (_canTsumo)
        {
            DetermineStrongestCompleteHand(completeHands);
            OnCanTsumo?.Invoke(this, EventArgs.Empty);
        }
    }

    private void DetermineStrongestCompleteHand(List<ICompleteHand> completeHands)
    {
        ICompleteHand strongestHand = completeHands[0];
        int highestValue = 0;
        foreach (ICompleteHand completeHand in completeHands)
        {
            int han = completeHand.GetYaku().Sum(yaku => yaku.GetValue());
            if (han <= highestValue) continue;
            highestValue = han;
            strongestHand = completeHand;
        }
        _completeHand = strongestHand;
        if (_completeHand.GetYaku().Count == 0)
            throw new Exception("No yaku");
        ClearYaku();
        SetSatisfiedYaku(_completeHand.GetYaku());
    }

    private List<ICompleteHand> GetAllCompleteHandsForTsumoCheck()
    {
        List<ICompleteHand> completeHands = new();
        foreach (ITenpaiHand tenpaiHand in _hand.GetTenpaiHands())
        {
            foreach (Tile waitTile in tenpaiHand.GetWaits())
            {
                if (AreTilesEquivalent(waitTile, _hand.GetDrawTile()))
                {
                    completeHands.Add(CompleteHandFactory.CreateCompleteHand(tenpaiHand, _hand.GetDrawTile(), this));
                }
            }
        }

        return completeHands;
    }

    private void InitializeValuesForTsumoCheck()
    {
        _canTsumo = false;
        _completeHand = null;
        ClearYaku();
    }

    public void SetSatisfiedYaku(List<YakuBase> yaku)
    {
        _satisfiedYaku = yaku;
    }

    public void ClearYaku()
    {
        _satisfiedYaku.Clear();
    }
    
    public void SetCompleteHand(ICompleteHand completeHand)
    {
        _completeHand = completeHand;
    }

    public List<YakuBase> GetYaku()
    {
        _satisfiedYaku ??= new List<YakuBase>();
        return _satisfiedYaku;
    }

    public string GetCompleteHandType()
    {
        return _completeHand.GetCompleteHandType().ToString();
    }

    public int NumberOfTenpaiHands()
    {
        return _hand.GetTenpaiHands().Count;
    }

    public int[] NumberOfWaitsPerTenpaiHand()
    {
        int[] waits = new int[NumberOfTenpaiHands()];
        for (int i = 0; i < NumberOfTenpaiHands(); i++)
        {
            waits[i] = _hand.GetTenpaiHands()[i].GetWaits().Count;
        }
        return waits;
    }

    internal ICompleteHand GetCompleteHand()
    {
        return _completeHand;
    }
#endregion

    private void CheckForDuplicatePlayers(Player player, Player existingPlayer1, Player existingPlayer2)
    {
        if (player == existingPlayer1 || player == existingPlayer2)
        {
            throw new ArgumentException("Attempted to set the same player in two locations");
        }
    }

    private void CheckThatThisPlayerIsNotDuplicated(Player player)
    {
        if (player == this)
        {
            throw new ArgumentException("Attempted to set this player to multiple locations");
        }
    }

    private static Tile? CountCopiesOfTile(Tile? tile, Tile t, ref int count)
    {
        if (AreTilesEquivalent(tile, t))
        {
            count++;
            return tile;
        }
        tile = t; 
        count = 1;
        return tile;
    }

    public int NumberOfCopiesVisible(Tile tile)
    {
        int total = _game.NumberOfCopiesVisible(tile);
        foreach (Tile t in _hand.GetTilesInHand())
        {
            if (AreTilesEquivalent(tile, t))
            {
                total++;
            }
        }
        return total;
    }
}