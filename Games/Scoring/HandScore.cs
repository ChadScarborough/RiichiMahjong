using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Yaku.StandardYaku;
using System.Collections.Generic;
using static RMU.Games.Scoring.ScoreCalculator;
using static RMU.Globals.Enums;

namespace RMU.Games.Scoring
{
    public class HandScore
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
            _hanValue = HanCalculator.CalculateHanValue(player, _satisfiedYaku);
            _fuValue = FuCalculator.CalculateFuValue(completeHand, winningCallType);
            _totalPointsReceived = CalculateTotalScore();
            SetName();
        }

        private int CalculateTotalScore()
        {
            if (_winningCallType == RON)
                return CalculateTotalRonScore();
            return CalculateTotalTsumoScore();
        }

        private int CalculateTotalRonScore()
        {
            if (_player.GetSeatWind() == EAST)
                return CalculateDealerRonScore(_hanValue, _fuValue);
            return CalculateNonDealerRonScore(_hanValue, _fuValue);
        }

        private int CalculateTotalTsumoScore()
        {
            if (_player.GetSeatWind() == EAST)
                return 3 * CalculateDealerTsumoScore(_hanValue, _fuValue);
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

        public Player GetPlayer() => _player;

        public List<YakuBase> GetYaku() => _satisfiedYaku;

        public int GetHanValue() => _hanValue;

        public int GetFuValue() => _fuValue;

        public int GetTotalPointsReceived() => _totalPointsReceived;

        public string GetWinningCallType() => _winningCallType.ToString();

        public override string ToString() => _name;
    }
}
