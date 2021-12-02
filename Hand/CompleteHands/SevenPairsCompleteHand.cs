using RMU.Globals;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands
{
    public class SevenPairsCompleteHand : ICompleteHand
    {
        private List<ICompleteHandComponent> _completeHand;

        public SevenPairsCompleteHand
            (
            Pair pair1, Pair pair2, Pair pair3, 
            Pair pair4, Pair pair5, Pair pair6, 
            IsolatedTile isolatedTile, DrawTile drawTile
            )
        {
            _completeHand = new List<ICompleteHandComponent>();
            FillList(pair1, pair2, pair3, pair4, pair5, pair6, isolatedTile, drawTile);
            //Seven pairs is always 25 fu
        }

        private void FillList
            (
            Pair pair1, Pair pair2, Pair pair3, 
            Pair pair4, Pair pair5, Pair pair6, 
            IsolatedTile isolatedTile, DrawTile drawTile
            )
        {
            _completeHand.Add(pair1);
            _completeHand.Add(pair2);
            _completeHand.Add(pair3);
            _completeHand.Add(pair4);
            _completeHand.Add(pair5);
            _completeHand.Add(pair6);
            _completeHand.Add(isolatedTile);
            _completeHand.Add(drawTile);
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            return _completeHand;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            return Enums.CompleteHandWaitType.PairWait;
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.CompleteHandType.SevenPairs;
        }
    }
}
