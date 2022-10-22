using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Players;
using RMU.Tiles;
using RMU.Yaku;

namespace RMU.Hands.CompleteHands;

public class NullCompleteHand : ICompleteHand
{
    private readonly Player _player;
    
    public NullCompleteHand(Player player)
    {
        _player = player;
    }
    
    public List<ICompleteHandComponent> GetComponents()
    {
        throw new System.NotImplementedException();
    }

    public CompleteHandWaitType GetWaitType()
    {
        throw new System.NotImplementedException();
    }

    public CompleteHandType GetCompleteHandType()
    {
        throw new System.NotImplementedException();
    }

    public bool IsOpen()
    {
        throw new System.NotImplementedException();
    }

    public ITenpaiHand GetTenpaiHand()
    {
        throw new System.NotImplementedException();
    }

    public List<ICompleteHandComponent> GetConstructedHandComponents()
    {
        throw new System.NotImplementedException();
    }

    public List<ICompleteHandComponent> GetTriplets()
    {
        throw new System.NotImplementedException();
    }

    public List<ICompleteHandComponent> GetSequences()
    {
        throw new System.NotImplementedException();
    }

    public List<ICompleteHandComponent> GetPairs()
    {
        throw new System.NotImplementedException();
    }

    public List<ICompleteHandComponent> GetIsolatedTiles()
    {
        throw new System.NotImplementedException();
    }

    public List<Tile> GetTiles()
    {
        throw new System.NotImplementedException();
    }

    public void ClearYaku()
    {
        throw new System.NotImplementedException();
    }

    public void SetYaku(List<YakuBase> satisfiedYaku)
    {
        throw new System.NotImplementedException();
    }

    public List<YakuBase> GetYaku()
    {
        throw new System.NotImplementedException();
    }

    public Player GetPlayer()
    {
        return _player;
    }
}