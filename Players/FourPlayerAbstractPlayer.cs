using System;
using RMU.Calls.CallCommands;
using RMU.Hands;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players
{
    public class FourPlayerAbstractPlayer : Player
    {
        private readonly AbstractFourPlayerHand _hand;

        private bool _canLowChii;
        private bool _canMidChii;
        private bool _canHighChii;
        
        protected FourPlayerAbstractPlayer(Wind seatWind, AbstractFourPlayerHand hand) : base(seatWind, hand)
        {
            _hand = hand;
        }

        public void CallLowChii(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canLowChii)
            {
                CallCommand callLowChii = new CallLowChiiCommand(this, calledTile);
                MakeCall(callLowChii);
                UpdateAvailableCalls();
            }
        }

        public void CallMidChii(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canMidChii)
            {
                CallCommand callMidChii = new CallMidChiiCommand(this, calledTile);
                MakeCall(callMidChii);
                UpdateAvailableCalls();
            }
        }

        public void CallHighChii(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canHighChii)
            {
                CallCommand callHighChii = new CallHighChiiCommand(this, calledTile);
                MakeCall(callHighChii);
                UpdateAvailableCalls();
            }
        }

        public override void GeneratePotentialDiscardCalls(TileObject lastTile)
        {
            base.GeneratePotentialDiscardCalls(lastTile);
            GeneratePotentialLowChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
            GeneratePotentialMidChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
            GeneratePotentialHighChiiCall(this, _priorityQueueForPotentialCalls, lastTile);
        }

        public override void UpdateAvailableCalls()
        {
            base.UpdateAvailableCalls();
            _canLowChii = _availablePotentialCalls.CanCallLowChii();
            _canMidChii = _availablePotentialCalls.CanCallMidChii();
            _canHighChii = _availablePotentialCalls.CanCallHighChii();
        }
    }
}