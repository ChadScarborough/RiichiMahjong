using RMU.Hand.CompleteHands.CompleteHandComponents;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
