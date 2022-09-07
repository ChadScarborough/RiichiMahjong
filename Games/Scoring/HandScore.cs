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


        public HandScore(Player player, List<YakuBase> satisfiedYaku)
        {
            _player = player;
            _satisfiedYaku = satisfiedYaku;
            _hanValue = HanCalculator.CalculateHanValue(player, satisfiedYaku);
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
    }
}
