using RMU.Hands.CompleteHands;
using RMU.Players;
using RMU.Walls;

namespace RMU.Yaku.StandardYaku;

public class UnderTheRiverYaku : YakuBase
{
    public UnderTheRiverYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Under the River";
        _value = 1;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        Player player = _completeHand.GetPlayer();
        if (player.IsActivePlayer()) return false;
        Wall wall = player.GetGame().GetWall();
        return wall.GetSize() == 0;
    }
}