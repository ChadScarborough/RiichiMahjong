using System;
using System.Collections.Generic;
using System.Text;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using RMU.Tiles;

namespace RMU.Hand.TenpaiHands
{
    public interface ITenpaiHand
    {
        List<ICompleteHandComponent> GetComponents();
        //List<TileObject> GetWaits();
    }
}
