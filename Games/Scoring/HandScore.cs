using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Yaku.StandardYaku;
using System.Collections.Generic;
using static RMU.Games.Scoring.ScoreCalculator;

namespace RMU.Games.Scoring;

public sealed class HandScore
{
    private readonly Player _player;
    private readonly List<YakuBase> _satisfiedYaku;
    private readonly WinningCallType _winningCallType;
    private readonly int _hanValue;
    private readonly int _fuValue;
    private readonly int _totalPointsReceived;
    private string _name;


    public HandScore(Player player, WinningCallType winningCallType)
    {
        _player = player;
        _satisfiedYaku = player.GetYaku();
        _winningCallType = winningCallType;
        ICompleteHand completeHand = player.GetCompleteHand();
        _hanValue = HanCalculator.Calculate(player, _satisfiedYaku);
        _fuValue = FuCalculator.Calculate(completeHand, winningCallType);
        _totalPointsReceived = CalculateTotalScore();
        SetName();
    }

    private int CalculateTotalScore()
    {
        return _winningCallType == RON ?
            CalculateTotalRonScore() :
            CalculateTotalTsumoScore();
    }

    private int CalculateTotalRonScore()
    {
        return _player.GetSeatWind() == EAST ?
            CalculateDealerRonScore(_hanValue, _fuValue) :
            CalculateNonDealerRonScore(_hanValue, _fuValue);
    }

    private int CalculateTotalTsumoScore()
    {
        if (_player.GetSeatWind() == EAST)
        {
            return 3 * CalculateDealerTsumoScore(_hanValue, _fuValue);
        }

        (int, int) scores = CalculateNonDealerTsumoScore(_hanValue, _fuValue);
        return (2 * scores.Item1) + scores.Item2;
    }

    private void SetName()
    {
        _name = "";
        foreach (YakuBase yaku in _satisfiedYaku)
        {
            _name += $"{yaku.GetName()}, ";
        }
        _name += $"{_hanValue} han {_fuValue} fu";
    }

    public Player GetPlayer()
    {
        return _player;
    }

    public List<YakuBase> GetYaku()
    {
        return _satisfiedYaku;
    }

    public int GetHanValue()
    {
        return _hanValue;
    }

    public int GetFuValue()
    {
        return _fuValue;
    }

    public int GetTotalPointsReceived()
    {
        return _totalPointsReceived;
    }

    public string GetWinningCallType()
    {
        return _winningCallType.ToString();
    }

    public override string ToString()
    {
        return _name;
    }
}
