using System;
using System.Collections.Generic;
using RMU.Globals;
using RMU.Hands.CompleteHands.CompleteHandComponents;

namespace RMU.Hands.CompleteHands
{
    public class ThirteenOrphansCompleteHand : ICompleteHand
    {
        public ThirteenOrphansCompleteHand()
        {
            //Take in list of isolated terminals (and likely one pair) and store them as ICompleteHandComponent
        }

        public List<ICompleteHandComponent> GetCompleteHand()
        {
            throw new NotImplementedException();
        }

        public Enums.CompleteHandType GetCompleteHandType()
        {
            return Enums.THIRTEEN_ORPHANS;
        }

        public Enums.CompleteHandWaitType GetWaitType()
        {
            throw new NotImplementedException();
        }
    }
}
