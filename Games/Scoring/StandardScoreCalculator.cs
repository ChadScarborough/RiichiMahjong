using System;

namespace RMU.Games.Scoring;

internal static class StandardScoreCalculator
{
    public static int CalculateDealerRonScore(int han, int fu)
    {
        return han switch
        {
            1 => Calculate1HanDealerRonScore(fu),
            2 => Calculate2HanDealerRonScore(fu),
            3 => Calculate3HanDealerRonScore(fu),
            4 => Calcualte4HanDealerRonScore(fu),
            >= 5 => CalculateDealerRonLimitScore(han),
            _ => InvalidHanValue()
        };
    }

    private static int Calculate1HanDealerRonScore(int fu)
    {
        return fu switch
        {
            30 => 1500,
            40 => 2000,
            50 => 2400,
            60 => 2900,
            70 => 3400,
            80 => 3900,
            90 => 4400,
            100 => 4800,
            110 => 5300,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate2HanDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 2400,
            30 => 2900,
            40 => 3900,
            50 => 4800,
            60 => 5800,
            70 => 6800,
            80 => 7700,
            90 => 8700,
            100 => 9600,
            110 => 10600,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate3HanDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 4800,
            30 => 5800,
            40 => 7700,
            50 => 9600,
            60 => 11600,
            >= 70 => 12000,
            _ => InvalidFuValue()
        };
    }

    private static int Calcualte4HanDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 9600,
            30 => 11600,
            >= 40 => 12000,
            _ => InvalidFuValue()
        };
    }

    private static int CalculateDealerRonLimitScore(int han)
    {
        return han switch
        {
            < 5 => InvalidHanValue(),
            5 => 12000,
            <= 7 => 18000,
            <= 10 => 24000,
            <= 12 => 36000,
            >= 13 => 48000
        };
    }

    public static int CalculateNonDealerRonScore(int han, int fu)
    {
        return han switch
        {
            1 => Calculate1HanNonDealerRonScore(fu),
            2 => Calculate2HanNonDealerRonScore(fu),
            3 => Calculate3HanNonDealerRonScore(fu),
            4 => Calculate4HanNonDealerRonScore(fu),
            >= 5 => CalculateNonDealerRonLimitScore(han),
            _ => InvalidHanValue()
        };
    }

    private static int Calculate1HanNonDealerRonScore(int fu)
    {
        return fu switch
        {
            30 => 1000,
            40 => 1300,
            50 => 1600,
            60 => 2000,
            70 => 2300,
            80 => 2600,
            90 => 2900,
            100 => 3200,
            110 => 3600,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate2HanNonDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 1600,
            30 => 2000,
            40 => 2600,
            50 => 3200,
            60 => 3900,
            70 => 4500,
            80 => 5200,
            90 => 5800,
            100 => 6400,
            110 => 7100,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate3HanNonDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 3200,
            30 => 3900,
            40 => 5200,
            50 => 6400,
            60 => 7700,
            >= 70 => 8000,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate4HanNonDealerRonScore(int fu)
    {
        return fu switch
        {
            25 => 6400,
            30 => 7700,
            >= 40 => 8000,
            _ => InvalidFuValue()
        };
    }

    private static int CalculateNonDealerRonLimitScore(int han)
    {
        return han switch
        {
            < 5 => InvalidHanValue(),
            5 => 8000,
            <= 7 => 12000,
            <= 10 => 16000,
            <= 12 => 24000,
            >= 13 => 32000
        };
    }

    // Returns the number of points taken per player--not the total number taken from all players
    public static int CalculateDealerTsumoScore(int han, int fu)
    {
        return han switch
        {
            1 => Calculate1HanDealerTsumoScore(fu),
            2 => Calculate2HanDealerTsumoScore(fu),
            3 => Calculate3HanDealerTsumoScore(fu),
            4 => Calculate4HanDealerTsumoScore(fu),
            >= 5 => CalculateDealerTsumoLimitScore(han),
            _ => InvalidHanValue()
        };
    }

    private static int Calculate1HanDealerTsumoScore(int fu)
    {
        return fu switch
        {
            30 => 500,
            40 => 700,
            50 => 800,
            60 => 1000,
            70 => 1200,
            80 => 1300,
            90 => 1500,
            100 => 1600,
            110 => 1800,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate2HanDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => 700,
            30 => 1000,
            40 => 1300,
            50 => 1600,
            60 => 2000,
            70 => 2300,
            80 => 2600,
            90 => 2900,
            100 => 3200,
            110 => 3600,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate3HanDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => 1300,
            25 => 1600,
            30 => 2000,
            40 => 2600,
            50 => 3200,
            60 => 3900,
            >= 70 => 4000,
            _ => InvalidFuValue()
        };
    }

    private static int Calculate4HanDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => 2600,
            25 => 3200,
            30 => 3900,
            >= 40 => 4000,
            _ => InvalidFuValue()
        };
    }

    private static int CalculateDealerTsumoLimitScore(int han)
    {
        return han switch
        {
            < 5 => InvalidHanValue(),
            5 => 4000,
            <= 7 => 6000,
            <= 10 => 8000,
            <= 12 => 12000,
            >= 13 => 16000
        };
    }

    // Returns a tuple representing the number of points taken from each non-dealer (Item1) and from the dealer (Item2)
    public static (int, int) CalculateNonDealerTsumoScore(int han, int fu)
    {
        return han switch
        {
            1 => Calculate1HanNonDealerTsumoScore(fu),
            2 => Calculate2HanNonDealerTsumoScore(fu),
            3 => Calculate3HanNonDealerTsumoScore(fu),
            4 => Calculate4HanNonDealerTsumoScore(fu),
            >= 5 => CalculateNonDealerTsumoLimitScore(han),
            _ => throw new Exception("Invalid han value")
        };
    }

    private static (int, int) Calculate1HanNonDealerTsumoScore(int fu)
    {
        return fu switch
        {
            30 => (300, 500),
            40 => (400, 700),
            50 => (400, 800),
            60 => (500, 1000),
            70 => (600, 1200),
            80 => (700, 1300),
            90 => (800, 1500),
            100 => (800, 1600),
            110 => (900, 1800),
            _ => throw new Exception("Invalid fu value")
        };
    }

    private static (int, int) Calculate2HanNonDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => (400, 700),
            30 => (500, 1000),
            40 => (700, 1300),
            50 => (800, 1600),
            60 => (1000, 2000),
            70 => (1200, 2300),
            80 => (1300, 2600),
            90 => (1500, 2900),
            100 => (1600, 3200),
            110 => (1800, 3600),
            _ => throw new Exception("Invalid fu value")
        };
    }

    private static (int, int) Calculate3HanNonDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => (700, 1300),
            25 => (800, 1600),
            30 => (1000, 2000),
            40 => (1300, 2600),
            50 => (1600, 3200),
            60 => (2000, 3900),
            >= 70 => (2000, 4000),
            _ => throw new Exception("Invalid fu value")
        };
    }

    private static (int, int) Calculate4HanNonDealerTsumoScore(int fu)
    {
        return fu switch
        {
            20 => (1300, 2600),
            25 => (1600, 3200),
            30 => (2000, 3900),
            >= 40 => (2000, 4000),
            _ => throw new Exception("Invalid fu value")
        };
    }

    private static (int, int) CalculateNonDealerTsumoLimitScore(int han)
    {
        return han switch
        {
            < 5 => throw new Exception("Invalid han value"),
            5 => (2000, 4000),
            <= 7 => (3000, 6000),
            <= 10 => (4000, 8000),
            <= 12 => (6000, 12000),
            >= 13 => (8000, 16000)
        };
    }

    private static int InvalidHanValue()
    {
        throw new Exception("Invalid han value");
    }

    private static int InvalidFuValue()
    {
        throw new Exception("Invalid fu value");
    }
}
