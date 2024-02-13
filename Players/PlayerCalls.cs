using RMU.Calls.CallCommands;
using RMU.Calls.CreateMeldBehaviours;
using RMU.Calls.PotentialCalls;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using RMU.Hands.TenpaiHands;
using RMU.Tiles;
using System;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players
{
    public abstract partial class Player
    {
        #region MemberVariables
        private bool _canPon;
        private bool _canOpenKan1;
        private bool _canOpenKan2;
        private bool _canRiichi;
        private bool _canRon;
        private bool _canTsumo;
        private bool _canClosedKan;

        private Tile[] _closedKanTiles;

        private Tile[] _riichiTiles;
        private bool _isPreRiichi;
        private bool _isInRiichi;

        protected PriorityQueueForPotentialCalls _priorityQueueForPotentialCalls;
        private PriorityQueueForCallCommands _priorityQueueForCallCommands;
        protected AvailablePotentialCalls _availablePotentialCalls;

        public event EventHandler OnCanPon;
        public event EventHandler OnCanHighChii;
        public event EventHandler OnCanHighChiiRed;
        public event EventHandler OnCanMidChii;
        public event EventHandler OnCanMidChiiRed;
        public event EventHandler OnCanLowChii;
        public event EventHandler OnCanLowChiiRed;
        public event EventHandler OnCanOpenKan1;
        public event EventHandler OnCanOpenKan2;
        public event EventHandler OnCanClosedKan;
        public event EventHandler OnCanRiichi;
        public event EventHandler OnCanRon;
        public event EventHandler OnCanTsumo;
        public event EventHandler OnCanNoLongerPon;
        public event EventHandler OnCanNoLongerChii;
        #endregion

        private void NegateCalls()
        {
            _canPon = false;
            _canRon = false;
            _canRiichi = false;
            _canTsumo = false;
            _canClosedKan = false;
            _canOpenKan1 = false;
            _canOpenKan2 = false;
        }

        #region Chii
        protected void InvokeOnCanHighChii()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanHighChii?.Invoke(this, tile);
        }

        protected void InvokeOnCanHighChiiRed()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanHighChiiRed?.Invoke(this, tile);
        }

        protected void InvokeOnCanMidChii()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanMidChii?.Invoke(this, tile);
        }

        protected void InvokeOnCanMidChiiRed()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanMidChiiRed?.Invoke(this, tile);
        }

        protected void InvokeOnCanLowChii()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanLowChii?.Invoke(this, tile);
        }

        protected void InvokeOnCanLowChiiRed()
        {
            EventArgTile tile = new(_game.GetLastTile());
            OnCanLowChiiRed?.Invoke(this, tile);
        }

        internal void InvokeOnCanNoLongerChii()
        {
            OnCanNoLongerChii?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Pon
        private void UpdateAvailablePonCall()
        {
            _canPon = _availablePotentialCalls.CanCallPon();
            if (CanPon())
                OnCanPon?.Invoke(this, EventArgs.Empty); //This will eventually need to pass the tile, but we'll get there when we get there
        }

        public bool CanPon()
        {
            if (IsActivePlayer())
                return false;
            if (_isInRiichi)
                return false;
            return _canPon;
        }

        public void CallPon(Tile calledTile)
        {
            if (CanPon())
            {
                CallCommand callPon = new CallPonCommand(this, calledTile);
                MakeCall(callPon);
                UpdateAvailableCalls();
            }
        }

        internal void InvokeOnCanNoLongerPon()
        {
            OnCanNoLongerPon?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Kan

        #region OpenKan1
        private void UpdateAvailableOpenKan1Call()
        {
            _canOpenKan1 = _availablePotentialCalls.CanCallOpenKan1();
            if (CanOpenKan1())
                OnCanOpenKan1?.Invoke(this, EventArgs.Empty);
        }
        public bool CanOpenKan1()
        {
            if (IsActivePlayer())
                return false;
            if (_isInRiichi)
                return false;
            return _canOpenKan1;
        }

        public void CallOpenKan1(Tile calledTile)
        {
            if (CanOpenKan1())
            {
                CallCommand callOpenKan1 = new CallOpenKan1Command(this, calledTile);
                MakeCall(callOpenKan1);
                UpdateAvailableCalls();
            }
        }
        #endregion

        #region OpenKan2
        private void CheckForOpenKan2()
        {
            if (_isInRiichi)
                return;
            List<OpenMeld> openMelds = _hand.GetOpenMelds();
            List<string> callable_tiles = new();
            foreach (OpenMeld om in openMelds)
            {
                if (om.GetMeldType() is not PON)
                    continue;
                Tile t = om.GetCalledTile();
                if (_hand.ContainsTile(t))
                    callable_tiles.Add(t.ToString());
            }
            if (callable_tiles.Count > 0)
            {
                _canOpenKan2 = true;
                OnCanOpenKan2?.Invoke(this, new EventArgTileArray(callable_tiles.ToArray()));
                return;
            }
            _canOpenKan2 = false;
        }

        public bool CanOpenKan2()
        {
            if (!IsActivePlayer())
                return false;
            if (_isInRiichi)
                return false;
            return _canOpenKan2;
        }

        public void CallOpenKan2(Tile calledTile)
        {
            if (CanOpenKan2())
            {
                CallCommand callOpenKan2 = new CallOpenKan2Command(this, calledTile);
                callOpenKan2.Execute();
                OnHandChanged?.Invoke(this, EventArgs.Empty);
                UpdateAvailableCalls();
                CheckForOpenKan2();
            }
        }
        #endregion

        #region ClosedKan
        private void CheckForClosedKan()
        {
            if (_isInRiichi)
            {
                Tile drawTile = _hand.GetDrawTile();
                foreach (ITenpaiHand tenpaiHand in _hand.GetTenpaiHands())
                {
                    bool containsClosedPon = false;
                    foreach (ICompleteHandComponent component in tenpaiHand.GetComponents())
                    {
                        if (component.GetComponentType() is CLOSED_PON && AreTilesEquivalent(component.GetLeadTile(), drawTile))
                        {
                            containsClosedPon = true;
                            continue;
                        }
                    }
                    if (containsClosedPon == false)
                        return;
                }
                _canClosedKan = true;
                string[] tileName = new string[] { drawTile.ToString() };
                OnCanClosedKan?.Invoke(this, new EventArgTileArray(tileName));
                return;
            }
            int count = 0;
            Tile? tile = null;
            List<Tile> tiles = new();
            foreach (Tile t in _hand.GetTilesInHand())
            {
                tile = CountCopiesOfTile(tile, t, ref count);
                if (count != 4) continue;
                _canClosedKan = true;
                tiles.Add(tile);
            }
            _canClosedKan = tiles.Count > 0;
            _closedKanTiles = tiles.ToArray();
            if (CanClosedKan())
            {
                List<string> tileNames = new();
                foreach (Tile t in _closedKanTiles)
                    tileNames.Add(t.ToString());
                OnCanClosedKan?.Invoke(this, new EventArgTileArray(tileNames.ToArray()));
            }
        }

        public bool CanClosedKan()
        {
            if (!IsActivePlayer())
                return false;
            if (_isInRiichi)
                return false; // Not accurate; fix later
            return _canClosedKan;
        }

        public void CallClosedKan(Tile calledTile)
        {
            if (_canClosedKan == false) return;
            if (IsActivePlayer() == false) return;
            CallCommand callClosedKan = new CallClosedKanCommand(this, calledTile);
            callClosedKan.Execute();
            _game.MakeDoraTiles();
            CheckForClosedKan();
            UpdateAvailableCalls();
            OnHandChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #endregion

        #region Riichi
        private void CheckForRiichi()
        {
            if (!this.IsActivePlayer())
                return;
            if (this.GetHand().IsOpen())
                return;
            if (this.GetHand().GetDrawTile() is null)
                return;
            if (this.GetHand().GetShanten() > 0)
                return;
            if (_isInRiichi)
                return;
            List<Tile> discardTiles = GetHand().GetRiichiDiscardTiles();
            List<string> tileNames = new();
            foreach (Tile t in discardTiles)
            {
                string s = t.ToString();
                tileNames.Add(s);
            }
            _riichiTiles = discardTiles.ToArray();
            _canRiichi = true;
            OnCanRiichi?.Invoke(this, new EventArgTileArray(tileNames.ToArray()));
        }

        public void CallRiichi()
        {
            if (_isInRiichi)
                return;
            _isPreRiichi = true;
        }
        #endregion

        #region Ron
        private void UpdateAvailableRonCall()
        {
            _canRon = _availablePotentialCalls.CanCallRon();
            if (CanRon())
                OnCanRon?.Invoke(this, EventArgs.Empty);
        }

        public bool CanRon()
        {
            if (IsActivePlayer())
                return false;
            return _canRon;
        }

        public void CallRon()
        {
            Tile calledTile = _game.GetLastTile();
            if (!_canRon) return;
            CallCommand callRon = new CallRonCommand(this, calledTile);
            MakeCall(callRon);
        }
        #endregion

        #region Tsumo
        public bool CanTsumo()
        {
            if (!IsActivePlayer())
                return false;
            return _canTsumo;
        }

        public void CallTsumo()
        {
            if (_canTsumo == false)
            {
                return;
            }

            _game.CallTsumo(this, _satisfiedYaku);
        }
        #endregion

        public void SetAvailablePotentialCalls()
        {
            _availablePotentialCalls = new AvailablePotentialCalls(this, _priorityQueueForPotentialCalls);
        }

        public void SetPriorityQueueForPotentialCalls(PriorityQueueForPotentialCalls queue)
        {
            _priorityQueueForPotentialCalls = queue;
        }

        public void SetPriorityQueueForCallCommands(PriorityQueueForCallCommands queue)
        {
            _priorityQueueForCallCommands = queue;
        }

        public void CancelCalls()
        {
            _priorityQueueForPotentialCalls.RemoveByPlayer(this);
            NegateCalls();
            UpdateAvailableCalls();
            if (_priorityQueueForPotentialCalls.IsEmpty())
            {
                _priorityQueueForCallCommands.Execute();
            }
        }

        protected void MakeCall(CallCommand command)
        {
            _priorityQueueForPotentialCalls.RemoveByPlayer(this);
            _priorityQueueForPotentialCalls.RemoveByPriority(command.GetPriority());
            _priorityQueueForCallCommands.AddCall(command);
            if (_priorityQueueForPotentialCalls.IsEmpty())
            {
                _priorityQueueForCallCommands.Execute();
            }
            OnHandChanged?.Invoke(this, EventArgs.Empty);
            NegateCalls();
            _game.SetActivePlayerAfterCall(this);
        }


        public virtual void GeneratePotentialDiscardCalls(Tile lastTile)
        {
            if (IsActivePlayer())
                return;
            if (!_isInRiichi)
            {
                GeneratePotentialPonAndKanCalls(this, _priorityQueueForPotentialCalls, lastTile);
            }
            GeneratePotentialRonCall(this, _priorityQueueForPotentialCalls, lastTile);
        }

        public virtual void UpdateAvailableCalls()
        {
            _availablePotentialCalls.UpdateAvailableCalls();
            UpdateAvailablePonCall();
            UpdateAvailableOpenKan1Call();
            UpdateAvailableRonCall();
        }
    }
}
