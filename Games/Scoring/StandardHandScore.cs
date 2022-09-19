using RMU.Players;
using static RMU.Games.Scoring.StandardScoreCalculator;

namespace RMU.Games.Scoring;

public sealed class StandardHandScore : HandScoreBase
{
    public StandardHandScore(Player player, WinningCallType winningCallType) : base(player, winningCallType)
    {

    }

    public override string GetScoreLimitName()
    {
        return (_hanValue, _fuValue) switch
        {
            ( >= 13, _) => "Kazoe Yakuman",
            ( >= 11, _) => "Sanbaiman",
            ( >= 8, _) => "Baiman",
            ( >= 6, _) => "Haneman",
            (5, _) or (4, >= 40) or (3, >= 70) => "Mangan",
            _ => ""
        };
    }

    private int CalculateTotalRonScore()
    {
        return _player.GetSeatWind() == EAST ?
            CalculateDealerRonScore(_hanValue, _fuValue) :
            CalculateNonDealerRonScore(_hanValue, _fuValue);
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
            return 3 * CalculateDealerTsumoScore(_hanValue, _fuValue);
        }

        (int, int) scores = CalculateNonDealerTsumoScore(_hanValue, _fuValue);
        return (2 * scores.Item1) + scores.Item2;
    }
}
