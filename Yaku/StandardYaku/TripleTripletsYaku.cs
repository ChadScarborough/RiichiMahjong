using System.Collections.Generic;
using RMU.Hands.CompleteHands;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Globals.Enums;

namespace RMU.Yaku.StandardYaku;

public class TripleTripletsYaku : Yaku
{
    public TripleTripletsYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Triple Triplets";
        _value = 2;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetCompleteHandType() is not STANDARD) return false;
        int numberOfTriplets = _completeHand.GetTriplets().Count;
        if (numberOfTriplets < 3) return false;
        for (int i = 0; i < numberOfTriplets - 2; i++)
        {
            for (int j = i + 1; j < numberOfTriplets - 1; j++)
            {
                for (int k = j + 1; k < numberOfTriplets; k++)
                {
                    if (TripletsFormTripleTriplets(i, j, k)) return true;
                }
            }
        }

        return false;
    }

    private bool TripletsFormTripleTriplets(int i, int j, int k)
    {
        bool sameValue = false;
        bool differentSuits = false;

        List<ICompleteHandComponent> triplets = _completeHand.GetTriplets();

        if (triplets[i].GetLeadTile().GetValue() == triplets[j].GetLeadTile().GetValue() &&
            triplets[j].GetLeadTile().GetValue() == triplets[k].GetLeadTile().GetValue())
        {
            sameValue = true;
        }

        if (triplets[i].GetLeadTile().GetSuit() is MAN &&
            triplets[j].GetLeadTile().GetSuit() is PIN &&
            triplets[k].GetLeadTile().GetSuit() is SOU)
        {
            differentSuits = true;
        }

        return sameValue && differentSuits;
    }
}