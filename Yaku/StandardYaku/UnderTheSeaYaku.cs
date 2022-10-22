using RMU.Games;
using RMU.Hands.CompleteHands;
using RMU.Walls;

namespace RMU.Yaku.StandardYaku;

public class UnderTheSeaYaku : YakuBase
{
    public UnderTheSeaYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Under the Sea";
        _value = 1;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        if (_completeHand.GetPlayer().IsActivePlayer() == false) return false;
        AbstractGame game = _completeHand.GetPlayer().GetGame();
        Wall wall = game.GetWall();
        return wall.GetSize() == 0;
    }
}