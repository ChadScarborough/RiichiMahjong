using RMU.Players;
using System;
using static RMU.Games.Scoring.YakumanScoreCalculator;

namespace RMU.Games.Scoring;

public class YakumanHandScore : HandScoreBase
{
    public YakumanHandScore(Player player, WinningCallType winningCallType) : base(player, winningCallType)
    {

    }

    public override string GetScoreLimitName()
    {
        return (_hanValue / 13) switch
        {
            1 => "Yakuman",
            2 => "Double Yakuman",
            3 => "Triple Yakuman",
            4 => "Quadruple Yakuman",
            5 => "Quintuple Yakuman",
            6 => "Sextuple Yakuman",
            _ => throw new Exception("Invalid han value for yakuman hand")
        };
    }

    private int CalculateTotalRonScore()
    {
        return _player.GetSeatWind() == EAST ?
            CalculateDealerRonScore(_hanValue) :
            CalculateNonDealerRonScore(_hanValue);
    }

    public override int CalculateTotalScore()
    {
        return _winningCallType == RON ?
            CalculateTotalRonScore() :
            CalculateTotalTsumoScore();
    }

    private int CalculateTotalTsumoScore()
    {
        if (_player.GetSeatWind() == EAST)
        {
            return 3 * CalculateDealerTsumoScore(_hanValue);
        }

        (int, int) scores = CalculateNonDealerTsumoScore(_hanValue);
        return (2 * scores.Item1) + scores.Item2;
    }
}