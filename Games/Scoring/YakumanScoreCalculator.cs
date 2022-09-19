namespace RMU.Games.Scoring;

internal static class YakumanScoreCalculator
{
    public static int CalculateDealerRonScore(int han)
    {
        if (han % 13 != 0)
        {
            throw new System.Exception("Invalid han value for yakuman hand");
        }

        int multiplier = han / 13;
        return multiplier is <= 0 or > 6
            ? throw new System.Exception("Invalid multiplier")
            : 48000 * multiplier;
    }

    public static int CalculateNonDealerRonScore(int han)
    {
        if (han % 13 != 0)
        {
            throw new System.Exception("Invalid han value for yakuman hand");
        }

        int multiplier = han / 13;
        return multiplier is <= 0 or > 6
            ? throw new System.Exception("Invalid multiplier")
            : 32000 * multiplier;
    }

    public static int CalculateDealerTsumoScore(int han)
    {
        if (han % 13 != 0)
        {
            throw new System.Exception("Invalid han value for yakuman hand");
        }

        int multiplier = han / 13;
        return multiplier is <= 0 or > 6
            ? throw new System.Exception("Invalid multiplier")
            : multiplier * 16000;
    }

    public static (int, int) CalculateNonDealerTsumoScore(int han)
    {
        if (han % 13 != 0)
        {
            throw new System.Exception("Invalid han value for yakuman hand");
        }

        int multiplier = han / 13;
        return multiplier is <= 0 or > 6
            ? throw new System.Exception("Invalid multiplier")
            : (multiplier * 8000, multiplier * 16000);
    }
}
