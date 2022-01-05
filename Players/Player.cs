using System;
using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Hands;
using RMU.Tiles;
using static RMU.Globals.Enums;

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
        private PriorityQueueForPotentialCalls _priorityQueueForPotentialCalls;
        private PriorityQueueForCallCommands _priorityQueueForCallCommands;

        protected Player(Wind seatWind, Hand hand)
        {
            _seatWind = seatWind;
            _hand = hand;
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

        protected void MakeCall(CallCommand command)
        {
            _priorityQueueForPotentialCalls.RemoveByPlayer(this);
            _priorityQueueForPotentialCalls.RemoveByPriority(command.GetPriority());
            _priorityQueueForCallCommands.AddCall(command);
        }
        
        public void CallPon(TileObject calledTile)
        {
            CallCommand callPon = new CallPonCommand(this, calledTile);
            MakeCall(callPon);
        }

        public void CallClosedKan(TileObject calledTile)
        {
            CallCommand callClosedKan = new CallClosedKanCommand(this, calledTile);
            MakeCall(callClosedKan);
        }

        public void CallOpenKan1(TileObject calledTile)
        {
            CallCommand callOpenKan1 = new CallOpenKan1Command(this, calledTile);
            MakeCall(callOpenKan1);
        }

        public void CallOpenKan2(TileObject calledTile)
        {
            CallCommand callOpenKan2 = new CallOpenKan2Command(this, calledTile);
            callOpenKan2.Execute();
        }

        public void CallRon(TileObject calledTile)
        {
            CallCommand callRon = new CallRonCommand(this, calledTile);
            MakeCall(callRon);
        }
    }
}
