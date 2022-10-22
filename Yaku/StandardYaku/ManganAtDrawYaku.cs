using System.Linq;
using RMU.DiscardPile;
using RMU.Hands.CompleteHands;
using RMU.Players;

namespace RMU.Yaku.StandardYaku;

public class ManganAtDrawYaku : YakuBase
{
    public ManganAtDrawYaku(ICompleteHand completeHand) : base(completeHand)
    {
        _name = "Mangan at Draw";
        _value = 5;
        _getValueBehaviour = new StandardGetValueBehaviour();
    }
    
    public override bool Check()
    {
        Player player = _completeHand.GetPlayer();
        IDiscardPile discardPile = player.GetHand().GetDiscardPile();
        return discardPile.GetDisplayedTileCount() == discardPile.GetTotalDiscardedCount() 
               && discardPile.GetDisplayedDiscardedTiles().All(tile => tile.IsTerminalOrHonor());
    }
}