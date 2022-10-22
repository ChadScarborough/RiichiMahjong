using RMU.Games;
using RMU.Hands.CompleteHands;
using RMU.Players;

namespace RMU.Yaku.Yakuman;

public class BlessingsOfHeavenYakuman : YakumanBase
{
    public BlessingsOfHeavenYakuman(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Blessings of Heaven";
        _value = 13;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }

    public override bool Check()
    {
        Player player = _completeHand.GetPlayer();
        AbstractGame game = player.GetGame();
        return game.IsFirstGoAround() && 
               player.GetSeatWind() is EAST;
    }
}