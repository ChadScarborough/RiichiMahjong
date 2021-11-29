using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;
using RMU.Globals;

namespace RMU.Hand.CompleteHands.CompleteHandComponents
{
    public static class CompleteHandGroupFactory
    {
        public static ICompleteHandGroup CreateCompleteHandGroup(List<TileObject> tiles, Enums.CompleteHandComponentType componentType)
        {
            switch (componentType)
            {
                case Enums.CompleteHandComponentType.ClosedPon:
                    return new ClosedPon(tiles);
                case Enums.CompleteHandComponentType.ClosedChii:
                    return new ClosedChii(tiles);
                default:
                    return null;
            }
        }

        public static ICompleteHandGroup CreateCompleteHandGroup(OpenMeld meld)
        {
            switch (meld.GetMeldType())
            {
                case Enums.MeldType.LowChii:
                case Enums.MeldType.MidChii:
                case Enums.MeldType.HighChii:
                    return new OpenChii(meld);
                case Enums.MeldType.Pon:
                    return new OpenPon(meld);
                case Enums.MeldType.OpenKan1:
                case Enums.MeldType.OpenKan2:
                    return new OpenKan(meld);
                case Enums.MeldType.ClosedKan:
                    return new ClosedKan(meld);
                default:
                    return null;
            }
        }
    }
}
