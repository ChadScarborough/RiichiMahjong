using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Games;
using RMU.Hands;
using RMU.Hands.TestHands;
using RMU.Players;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;

namespace RMUTests.CallsTests
{
    [TestClass]
    public class CallPriorityTest
    {
        private TestHand _hand1;
        private FourPlayerTestPlayer _player1;
        private TestHand _hand2;
        private FourPlayerTestPlayer _player2;
        private PriorityQueueForPotentialCalls _potentialCallQueue;
        private PriorityQueueForCallCommands _callCommandQueue;
        private FourPlayerGame _game;

        private void Setup()
        {
            _game = new FourPlayerNoRedFivesGame();
            _hand1 = new CallsTestHand();
            _player1 = new FourPlayerTestPlayer(_hand1);
            _hand2 = new CallsTestHand2();
            _player2 = new FourPlayerTestPlayer(_hand2);
            _potentialCallQueue = new PriorityQueueForPotentialCalls();
            _callCommandQueue = new PriorityQueueForCallCommands(_game);
            _player1.SetPriorityQueueForPotentialCalls(_potentialCallQueue);
            _player1.SetPriorityQueueForCallCommands(_callCommandQueue);
            _player1.SetAvailablePotentialCalls();
            _player2.SetPriorityQueueForPotentialCalls(_potentialCallQueue);
            _player2.SetPriorityQueueForCallCommands(_callCommandQueue);
            _player2.SetAvailablePotentialCalls();
        }

        [TestMethod]
        public void CallChii_IsDelayed_WhenThereAreMultiplePotentialCallsInTheQueue()
        {
            Setup();
            Tile lastTile = THREE_MAN;
            _player1.GeneratePotentialDiscardCalls(lastTile);
            _player2.GeneratePotentialDiscardCalls(lastTile);
            Assert.AreEqual(0, _hand1.GetOpenMelds().Count);
            
            _player1.CallLowChii(lastTile);
            
            Assert.AreEqual(0, _hand1.GetOpenMelds().Count);

            _player2.CancelCalls();
            
            Assert.AreEqual(1, _hand1.GetOpenMelds().Count);
        }

        [TestMethod]
        public void CallPon_ExecutesImmediately_IfThereAreCallChiiPotentialCallsInTheQueue()
        {
            Setup();
            Tile lastTile = THREE_MAN;
            _player1.GeneratePotentialDiscardCalls(lastTile);
            _player2.GeneratePotentialDiscardCalls(lastTile);
            Assert.AreEqual(0, _hand2.GetOpenMelds().Count);
            
            _player2.CallPon(lastTile);
            
            Assert.AreEqual(1, _hand2.GetOpenMelds().Count);
            
            _player1.CallLowChii(lastTile);
            
            Assert.AreEqual(0, _hand1.GetOpenMelds().Count);
        }

        [TestMethod]
        public void CallChii_IsSuperceded_WhenPonIsCalledAfterward()
        {
            Setup();
            Tile lastTile = THREE_MAN;
            _player1.GeneratePotentialDiscardCalls(lastTile);
            _player2.GeneratePotentialDiscardCalls(lastTile);
            _player1.CallMidChii(lastTile);
            _player2.CallPon(lastTile);
            
            Assert.AreEqual(0, _hand1.GetOpenMelds().Count);
            Assert.AreEqual(1, _hand2.GetOpenMelds().Count);
        }
    }
}