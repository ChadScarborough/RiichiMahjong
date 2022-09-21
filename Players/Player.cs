using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Games;
using RMU.Hands;
using RMU.Hands.CompleteHands;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using RMU.Yaku;
using RMU.Yaku.StandardYaku;
using RMU.Yaku.Yakuman;
using System;
using System.Collections.Generic;
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
    protected List<YakuBase> _satisfiedYaku;

    private bool _canPon;
    private bool _canOpenKan1;
    private bool _canRon;
    private bool _canTsumo;

    private int _playerID;

    protected Player(Wind seatWind, Hand hand, AbstractGame game)
    {
        _seatWind = seatWind;
        _hand = hand;
        _game = game;
        SetAvailablePotentialCalls();
    }

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

    public void Discard(int index)
    {
        if (IsActivePlayer())
        {
            Tile tile = _hand.GetClosedTiles()[index].Clone();
            _hand.DiscardTile(index);
            _game.SetLastTile(tile);
            _game.CheckCalls();
        }
    }

    public void DiscardDrawTile()
    {
        if (IsActivePlayer())
        {
            Tile tile = _hand.GetDrawTile().Clone();
            _hand.DiscardDrawTile();
            _game.SetLastTile(tile);
            _game.CheckCalls();
        }
    }

    public void DrawTile()
    {
        _hand.DrawTileFromWall();
        CheckForTsumo();
    }

    public void DrawTileFromDeadWall()
    {
        _hand.DrawTileFromDeadWall();
        CheckForTsumo();
    }

    public void SetAvailablePotentialCalls()
    {
        _availablePotentialCalls = new AvailablePotentialCalls(this, _priorityQueueForPotentialCalls);
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
    }

    public bool CanPon()
    {
        return _canPon;
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
        CheckForTsumo();
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

    public void CallClosedKan(Tile calledTile)
    {
        CallCommand callClosedKan = new CallClosedKanCommand(this, calledTile);
        callClosedKan.Execute();
        UpdateAvailableCalls();
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
        if (_canRon)
        {
            CallCommand callRon = new CallRonCommand(this, calledTile);
            MakeCall(callRon);
        }
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
        //GeneratePotentialPonAndKanCalls(this, _priorityQueueForPotentialCalls, lastTile);
        GeneratePotentialRonCall(this, _priorityQueueForPotentialCalls, lastTile);
    }

    public virtual void UpdateAvailableCalls()
    {
        _availablePotentialCalls.UpdateAvailableCalls();
        _canPon = _availablePotentialCalls.CanCallPon();
        _canOpenKan1 = _availablePotentialCalls.CanCallOpenKan1();
        _canRon = _availablePotentialCalls.CanCallRon();
    }

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
        }

        _canTsumo = AtLeastOneYakuSatisfied(completeHands);

        if (_canTsumo)
        {
            DetermineStrongestCompleteHand(completeHands);
        }
    }

    private void DetermineStrongestCompleteHand(List<ICompleteHand> completeHands)
    {
        ICompleteHand strongestHand = completeHands[0];
        int highestValue = 0;
        foreach (ICompleteHand completeHand in completeHands)
        {
            int han = 0;
            foreach (YakuBase yaku in completeHand.GetYaku())
            {
                han += yaku.GetValue();
            }
            if (han > highestValue)
            {
                highestValue = han;
                strongestHand = completeHand;
            }
        }
        _completeHand = strongestHand;
        _satisfiedYaku = _completeHand.GetYaku();
    }

    private static bool AtLeastOneYakuSatisfied(List<ICompleteHand> completeHands)
    {
        bool yakuSatisfied = false;
        foreach (ICompleteHand completeHand in completeHands)
        {
            YakumanList yakumanList = new(completeHand);
            StandardYakuList yakuList = new(completeHand);
            List<YakuBase> satisfiedYaku = new();
            satisfiedYaku.AddRange(yakumanList.CheckYakuman());
            if (satisfiedYaku.Count == 0)
            {
                satisfiedYaku.AddRange(yakuList.CheckYaku());
            }

            completeHand.SetYaku(satisfiedYaku);
            if (satisfiedYaku.Count > 0)
            {
                yakuSatisfied = true;
            }
        }
        return yakuSatisfied;
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
        _satisfiedYaku = null;
    }

    public void SetSatisfiedYaku(List<YakuBase> yaku)
    {
        _satisfiedYaku = yaku;
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
        return _completeHand == null ? "None" : _completeHand.GetCompleteHandType().ToString();
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

    public override string ToString()
    {
        return $"Player { _playerID }";
    }
}