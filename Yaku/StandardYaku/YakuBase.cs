using RMU.Hands.CompleteHands;

namespace RMU.Yaku.StandardYaku;

public abstract class YakuBase
{
    protected IGetValueBehaviour _getValueBehaviour;
    protected readonly ICompleteHand _completeHand;
    protected int _value;
    protected string _name;

    protected YakuBase(ICompleteHand completeHand)
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