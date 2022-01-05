using RMU.Player;
using static RMU.Globals.Enums;

namespace RMU.Calls.PotentialCalls
{
    public abstract class PotentialCall
    {
        private readonly AbstractPlayer _playerMakingCall;

        protected PotentialCall(AbstractPlayer playerMakingCall)
        {
            _playerMakingCall = playerMakingCall;
        }

        public abstract PotentialCallType GetCallType();

        public AbstractPlayer GetPlayerMakingCall()
        {
            return _playerMakingCall;
        }

        public abstract int GetPriority();
    }
}