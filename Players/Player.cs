using System;
using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Hands;
using RMU.Tiles;
using RMU.Games;
using static RMU.Globals.Enums;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMU.Players
{
    public abstract class Player
    {
        private Wind _seatWind;
        private readonly Hand _hand;
        private Player _playerOnLeft;
        private Player _playerAcross;
        private Player _playerOnRight;
        private int _score;
        private AbstractGame _game;
        protected PriorityQueueForPotentialCalls _priorityQueueForPotentialCalls;
        private PriorityQueueForCallCommands _priorityQueueForCallCommands;
        protected AvailablePotentialCalls _availablePotentialCalls;

        private bool _canPon;
        private bool _canOpenKan1;
        private bool _canRon;
        
        protected Player(Wind seatWind, Hand hand, AbstractGame game)
        {
            _seatWind = seatWind;
            _hand = hand;
            _game = game;
        }

        public bool IsActivePlayer()
        {
            return _game.GetActivePlayer().Equals(this);
        }

        public void Discard(int index)
        {
            if (IsActivePlayer())
            {
                _hand.DiscardTile(index);
                _game.NextPlayer();
            }
        }

        public void DiscardDrawTile()
        {
            if (IsActivePlayer())
            {
                _hand.DiscardDrawTile();
                _game.NextPlayer();
            }
        }

        public void DrawTile()
        {
            _hand.DrawTileFromWall();
        }

        public void DrawTileFromDeadWall()
        {
            _hand.DrawTileFromDeadWall();
        }

        public void SetAvailablePotentialCalls()
        {
            _availablePotentialCalls = new AvailablePotentialCalls(this, _priorityQueueForPotentialCalls);
        }

        public Hand GetHand()
        {
            return _hand;
        }

        public Wind GetSeatWind()
        {
            return _seatWind;
        }

        public void SetSeatWind(Wind seatWind)
        {
            _seatWind = seatWind;
        }

        public void SetScore(int score)
        {
            _score = score;
        }

        public int GetScore()
        {
            return _score;
        }

        public void SetPlayerOnLeft(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerAcross(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnLeft = player;
        }
        
        public void SetPlayerAcross(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerOnRight());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerAcross = player;
        }

        public void SetPlayerOnRight(Player player)
        {
            CheckForDuplicatePlayers(player, GetPlayerOnLeft(), GetPlayerAcross());
            CheckThatThisPlayerIsNotDuplicated(player);
            _playerOnRight = player;
        }

        public Player GetPlayerOnLeft()
        {
            return _playerOnLeft;
        }

        public Player GetPlayerAcross()
        {
            return _playerAcross;
        }

        public Player GetPlayerOnRight()
        {
            return _playerOnRight;
        }

        private void CheckForDuplicatePlayers(Player player, Player existingPlayer1, Player existingPlayer2)
        {
            if (player == existingPlayer1 || player == existingPlayer2)
            {
                throw new ArgumentException("Attempted to set the same player in two locations");
            }
        }

        private void CheckThatThisPlayerIsNotDuplicated(Player player)
        {
            if(player == this)
            {
                throw new ArgumentException("Attempted to set this player to multiple locations");
            }
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
        }
        
        public void CallPon(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canPon)
            {
                CallCommand callPon = new CallPonCommand(this, calledTile);
                MakeCall(callPon);
                UpdateAvailableCalls();
            }
        }

        public void CallClosedKan(TileObject calledTile)
        {
            CallCommand callClosedKan = new CallClosedKanCommand(this, calledTile);
            callClosedKan.Execute();
            UpdateAvailableCalls();
        }

        public void CallOpenKan1(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canOpenKan1)
            {
                CallCommand callOpenKan1 = new CallOpenKan1Command(this, calledTile);
                MakeCall(callOpenKan1);
                UpdateAvailableCalls();
            }
        }

        public void CallOpenKan2(TileObject calledTile)
        {
            CallCommand callOpenKan2 = new CallOpenKan2Command(this, calledTile);
            callOpenKan2.Execute();
            UpdateAvailableCalls();
        }

        public void CallRon(TileObject calledTile)
        {
            UpdateAvailableCalls();
            if (_canRon)
            {
                CallCommand callRon = new CallRonCommand(this, calledTile);
                MakeCall(callRon); 
            }
        }

        public virtual void GeneratePotentialDiscardCalls(TileObject lastTile)
        {
            GeneratePotentialPonAndKanCalls(this, _priorityQueueForPotentialCalls, lastTile);
            GeneratePotentialRonCall(this, _priorityQueueForPotentialCalls, lastTile);
        }

        public virtual void UpdateAvailableCalls()
        {
            _availablePotentialCalls.UpdateAvailableCalls();
            _canPon = _availablePotentialCalls.CanCallPon();
            _canOpenKan1 = _availablePotentialCalls.CanCallOpenKan1();
            _canRon = _availablePotentialCalls.CanCallRon();
        }
    }
}
