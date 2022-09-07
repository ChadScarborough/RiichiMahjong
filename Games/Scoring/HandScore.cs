using RMU.Players;
using RMU.Yaku.StandardYaku;
using System.Collections.Generic;

namespace RMU.Games.Scoring
{
    public class HandScore
    {
        private Player _player;
        private List<YakuBase> _satisfiedYaku;
        private int _hanValue;
        private string _name;


        public HandScore(Player player, List<YakuBase> satisfiedYaku)
        {
            _player = player;
            _satisfiedYaku = satisfiedYaku;
            _hanValue = HanCalculator.CalculateHanValue(player, satisfiedYaku);
            SetName();
        }

        private void SetName()
        {
            _name = "";
            foreach (YakuBase yaku in _satisfiedYaku)
            {
                _name += $"{yaku.GetName()}, ";
            }
            _name += $"{_hanValue} han";
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

        public override string ToString()
        {
            return _name;
        }
    }
}
