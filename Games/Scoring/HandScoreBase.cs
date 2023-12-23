using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Yaku;
using System;

namespace RMU.Games.Scoring
{
    public abstract class HandScoreBase : EventArgs
    {
        protected readonly Player _player;
        private readonly List<YakuBase> _satisfiedYaku;
        protected readonly WinningCallType _winningCallType;
        protected readonly int _hanValue;
        protected readonly int _fuValue;
        private readonly int _totalPointsReceived;
        private string _name;

        protected HandScoreBase(Player player, WinningCallType winningCallType)
        {
            _player = player;
            _satisfiedYaku = player.GetYaku();
            _winningCallType = winningCallType;
            ICompleteHand completeHand = player.GetCompleteHand();
            _hanValue = HanCalculator.Calculate(player, _satisfiedYaku);
            if (_hanValue < 5)
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

        protected abstract int CalculateTotalScore();

        private void SetName()
        {
            _name = "";
            foreach (YakuBase yaku in _satisfiedYaku)
            {
                _name += yaku.GetName();
                _name += ", ";
            }
            _name += _hanValue.ToString();
            _name += " han ";
            if (_fuValue > 0)
            {
                _name += _fuValue.ToString();
                _name += " fu";
            }
            string scoreLimitName = this.GetScoreLimitName();
            if (scoreLimitName is not "")
            {
                _name += $" -- {scoreLimitName}";
            }
        }

        public abstract string GetScoreLimitName();
    }
}