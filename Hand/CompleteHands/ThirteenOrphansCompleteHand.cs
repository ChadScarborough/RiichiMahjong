using RMU.Globals;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using System;
using System.Collections.Generic;

namespace RMU.Hand.CompleteHands
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
