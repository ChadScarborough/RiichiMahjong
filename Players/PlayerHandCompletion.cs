using RMU.Hands.CompleteHands;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using RMU.Yaku;
using System;
using System.Linq;


namespace RMU.Players
{
    public abstract partial class Player
    {
        private ICompleteHand _completeHand;
        private List<YakuBase> _satisfiedYaku;

        private void CheckForTsumo()
        {
            InitializeValuesForTsumoCheck();
            if (IsActivePlayer() is false)
            {
                return;
            }

            if (_hand.GetShanten() > -1)
            {
                return;
            }

            List<ICompleteHand> completeHands = GetAllCompleteHandsForTsumoCheck();
            if (completeHands.Count == 0)
            {
                Console.WriteLine("No complete hands constructed");
                return;
            }

            _canTsumo = AtLeastOneYakuSatisfied(completeHands);

            if (_canTsumo)
            {
                DetermineStrongestCompleteHand(completeHands);
                OnCanTsumo?.Invoke(this, EventArgs.Empty);
            }
        }

        private void DetermineStrongestCompleteHand(List<ICompleteHand> completeHands)
        {
            ICompleteHand strongestHand = completeHands[0];
            int highestValue = 0;
            foreach (ICompleteHand completeHand in completeHands)
            {
                int han = completeHand.GetYaku().Sum(yaku => yaku.GetValue());
                if (han <= highestValue) continue;
                highestValue = han;
                strongestHand = completeHand;
            }
            _completeHand = strongestHand;
            if (_completeHand.GetYaku().Count == 0)
                throw new Exception("No yaku");
            ClearYaku();
            SetSatisfiedYaku(_completeHand.GetYaku());
        }

        private List<ICompleteHand> GetAllCompleteHandsForTsumoCheck()
        {
            List<ICompleteHand> completeHands = new();
            foreach (ITenpaiHand tenpaiHand in _hand.GetTenpaiHands())
            {
                foreach (Tile waitTile in tenpaiHand.GetWaits())
                {
                    if (AreTilesEquivalent(waitTile, _hand.GetDrawTile()))
                    {
                        completeHands.Add(CompleteHandFactory.CreateCompleteHand(tenpaiHand, _hand.GetDrawTile(), this));
                    }
                }
            }

            return completeHands;
        }

        private void InitializeValuesForTsumoCheck()
        {
            _canTsumo = false;
            _completeHand = null;
            ClearYaku();
        }

        public void SetSatisfiedYaku(List<YakuBase> yaku)
        {
            _satisfiedYaku = yaku;
        }

        public void ClearYaku()
        {
            _satisfiedYaku.Clear();
        }

        public void SetCompleteHand(ICompleteHand completeHand)
        {
            _completeHand = completeHand;
        }

        public List<YakuBase> GetYaku()
        {
            _satisfiedYaku ??= new List<YakuBase>();
            return _satisfiedYaku;
        }

        public string GetCompleteHandType()
        {
            return _completeHand.GetCompleteHandType().ToString();
        }

        public int NumberOfTenpaiHands()
        {
            return _hand.GetTenpaiHands().Count;
        }

        public int[] NumberOfWaitsPerTenpaiHand()
        {
            int[] waits = new int[NumberOfTenpaiHands()];
            for (int i = 0; i < NumberOfTenpaiHands(); i++)
            {
                waits[i] = _hand.GetTenpaiHands()[i].GetWaits().Count;
            }
            return waits;
        }

        internal ICompleteHand GetCompleteHand()
        {
            return _completeHand;
        }

        private void CheckForDuplicatePlayers(Player player, Player existingPlayer1, Player existingPlayer2)
        {
            if (player == existingPlayer1 || player == existingPlayer2)
                throw new ArgumentException("Attempted to set the same player in two locations");
        }

        private void CheckThatThisPlayerIsNotDuplicated(Player player)
        {
            if (player == this)
                throw new ArgumentException("Attempted to set this player to multiple locations");
        }

        private static Tile? CountCopiesOfTile(Tile? tile, Tile t, ref int count)
        {
            if (AreTilesEquivalent(tile, t))
            {
                count++;
                return tile;
            }
            tile = t;
            count = 1;
            return tile;
        }

        public int NumberOfCopiesVisible(Tile tile)
        {
            int total = _game.NumberOfCopiesVisible(tile);
            foreach (Tile t in _hand.GetTilesInHand())
            {
                if (AreTilesEquivalent(tile, t))
                    total++;
            }
            return total;
        }
    }
}
