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
            PairComponent pair1, PairComponent pair2, PairComponent pair3, 
            PairComponent pair4, PairComponent pair5, PairComponent pair6, 
            IsolatedTile isolatedTile, DrawTile drawTile
            )
        {
            _completeHand = new List<ICompleteHandComponent>();
            FillList(pair1, pair2, pair3, pair4, pair5, pair6, isolatedTile, drawTile);
            //Seven pairs is always 25 fu
        }

        private void FillList
            (
            PairComponent pair1, PairComponent pair2, PairComponent pair3, 
            PairComponent pair4, PairComponent pair5, PairComponent pair6, 
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
            return Enums.PAIR_WAIT;
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.SEVEN_PAIRS;
        }
    }
}
