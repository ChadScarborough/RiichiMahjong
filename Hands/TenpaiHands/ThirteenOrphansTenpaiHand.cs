using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Tiles;
using System.Collections.Generic;

namespace RMU.Hands.TenpaiHands;

public abstract class ThirteenOrphansTenpaiHand : ITenpaiHand
{
    protected List<Tile> _waits;
    protected readonly List<ICompleteHandComponent> _components;

    protected ThirteenOrphansTenpaiHand(List<ICompleteHandComponent> components)
    {
        _components = components;
    }

    public List<ICompleteHandComponent> GetComponents()
    {
        return _components;
    }

    public virtual List<Tile> GetWaits()
    {
        return _waits;
    }

    public abstract CompleteHandWaitType GetWaitType();
    public CompleteHandType GetHandType()
    {
        return THIRTEEN_ORPHANS;
    }
}