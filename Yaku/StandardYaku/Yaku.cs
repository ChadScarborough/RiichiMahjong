using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public abstract class Yaku
{
    protected IGetValueBehaviour _getValueBehaviour;
    protected readonly ICompleteHand _completeHand;
    protected int _value;
    protected string _name;

    protected Yaku(ICompleteHand completeHand)
    {
        _completeHand = completeHand;
    }
    
    public abstract bool Check();

    public int GetValue()
    {
        return _getValueBehaviour.GetValue(_completeHand, _value);
    }

    public string GetName()
    {
        return _name;
    }
}