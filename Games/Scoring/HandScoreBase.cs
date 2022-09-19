using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Yaku;
using System.Collections.Generic;

namespace RMU.Games.Scoring
{
    public abstract class HandScoreBase
    {
        protected Player _player;
        protected List<YakuBase> _satisfiedYaku;
        protected WinningCallType _winningCallType;
        protected int _hanValue;
        protected int _fuValue;
        protected int _totalPointsReceived;
        protected string _name;

        public HandScoreBase(Player player, WinningCallType winningCallType)
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

        public int GetFuValue()
        {
            return _fuValue;
        }

        public int GetHanValue()
        {
            return _hanValue;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        public int GetTotalPointsReceived()
        {
            return _totalPointsReceived;
        }

        public string GetWinningCallType()
        {
            return _winningCallType.ToString();
        }

        public List<YakuBase> GetYaku()
        {
            return _satisfiedYaku;
        }

        public override string ToString()
        {
            return _name;
        }

        public abstract int CalculateTotalScore();

        protected void SetName()
        {
            _name = "";
            foreach (YakuBase yaku in _satisfiedYaku)
            {
                _name += $"{yaku.GetName()}, ";
            }
            _name += $"{_hanValue} han {_fuValue} fu";
        }

        public abstract string GetScoreLimitName();
    }
}