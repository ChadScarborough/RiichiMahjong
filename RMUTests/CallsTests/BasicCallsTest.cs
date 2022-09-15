using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Players;
using RMU.Hands.TestHands;
using RMU.Hands;
using RMU.Calls.CallCommands;
using RMU.Calls.PotentialCalls;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;
using static RMU.Calls.PotentialCalls.PotentialCallGenerator;

namespace RMUTests.CallsTests
{
    [TestClass]
    public class BasicCallsTest
    {
        private AbstractFourPlayerHand _hand;
        private FourPlayerTestPlayer _player;
        private PriorityQueueForPotentialCalls _potentialCallQueue;
        private PriorityQueueForCallCommands _callCommandQueue;

        private void Setup()
        {
            _hand = new CallsTestHand();
            _player = new FourPlayerTestPlayer(_hand);
            _potentialCallQueue = new PriorityQueueForPotentialCalls();
            _callCommandQueue = new PriorityQueueForCallCommands();
            _player.SetPriorityQueueForPotentialCalls(_potentialCallQueue);
            _player.SetPriorityQueueForCallCommands(_callCommandQueue);
            _player.SetAvailablePotentialCalls();
        }

        private int CountTileInstances(Tile tile)
        {
            int counter = 0;
            foreach (Tile t in _hand.GetClosedTiles())
            {
                if (AreTilesEquivalent(tile, t))
                {
                    counter++;
                }
            }

            return counter;
        }

        [TestMethod]
        public void CallPon_RemovesTwoCopiesOfTileFromHand_BasedOnCalledTile()
        {
            Setup();
            Assert.AreEqual(2, CountTileInstances(FIVE_SOU));
            
            GeneratePotentialPonAndKanCalls(_player, _potentialCallQueue, FIVE_SOU);
            
            _player.CallPon(FIVE_SOU);
            
            Assert.AreEqual(0, CountTileInstances(FIVE_SOU));
        }

        [TestMethod]
        public void CallOpenKan1_RemovesThreeCopiesOfTileFromHand_BasedOnCalledTile()
        {
            Setup();
            Assert.AreEqual(3, CountTileInstances(SEVEN_PIN));
            
            GeneratePotentialPonAndKanCalls(_player, _potentialCallQueue, SEVEN_PIN);
            
            _player.CallOpenKan1(SEVEN_PIN);
            
            Assert.AreEqual(0, CountTileInstances(SEVEN_PIN));
        }

        [TestMethod]
        public void CallLowChii_RemovesTilesOneAndTwoBelowCalledTile()
        {
            Setup();
            Assert.AreEqual(1, CountTileInstances(TWO_MAN));
            Assert.AreEqual(1, CountTileInstances(ONE_MAN));
            
            GeneratePotentialLowChiiCall(_player, _potentialCallQueue, THREE_MAN);

            _player.CallLowChii(THREE_MAN);
            
            Assert.AreEqual(0, CountTileInstances(TWO_MAN));
            Assert.AreEqual(0, CountTileInstances(ONE_MAN));
        }

        [TestMethod]
        public void CallMidChii_RemovesTilesOneBelowAndOneAboveCalledTile()
        {
            Setup();
            Assert.AreEqual(1, CountTileInstances(TWO_MAN));
            Assert.AreEqual(1, CountTileInstances(FOUR_MAN));
            
            GeneratePotentialMidChiiCall(_player, _potentialCallQueue, THREE_MAN);
            
            _player.CallMidChii(THREE_MAN);
            
            Assert.AreEqual(0, CountTileInstances(TWO_MAN));
            Assert.AreEqual(0, CountTileInstances(FOUR_MAN));
        }

        [TestMethod]
        public void CallHighChii_RemovesTilesOneAndTwoAboveCalledTile()
        {
            Setup();
            Assert.AreEqual(1, CountTileInstances(FOUR_MAN));
            Assert.AreEqual(1, CountTileInstances(FIVE_MAN));
            
            GeneratePotentialHighChiiCall(_player, _potentialCallQueue, FOUR_MAN);
            
            _player.CallHighChii(THREE_MAN);
            
            Assert.AreEqual(0,CountTileInstances(FOUR_MAN));
            Assert.AreEqual(0, CountTileInstances(FIVE_MAN));
        }

        [TestMethod]
        public void CallPon_CreatesNewPonOpenMeldObject()
        {
            Setup();
            GeneratePotentialPonAndKanCalls(_player, _potentialCallQueue, FIVE_SOU);
            _player.CallPon(FIVE_SOU);
            Assert.AreEqual(1, _player.GetHand().GetOpenMelds().Count);
            Assert.AreEqual(PON, _player.GetHand().GetOpenMelds()[0].GetMeldType());
        }

        [TestMethod]
        public void CallOpenKan1_CreatesNewOpenKan1OpenMeldObject()
        {
            Setup();
            GeneratePotentialPonAndKanCalls(_player, _potentialCallQueue, SEVEN_PIN);
            _player.CallOpenKan1(SEVEN_PIN);
            Assert.AreEqual(1, _player.GetHand().GetOpenMelds().Count);
            Assert.AreEqual(OPEN_KAN_1, _player.GetHand().GetOpenMelds()[0].GetMeldType());
        }

        [TestMethod]
        public void CallLowChii_CreatesNewLowChiiOpenMeldObject()
        {
            Setup();
            GeneratePotentialLowChiiCall(_player, _potentialCallQueue, THREE_MAN);
            _player.CallLowChii(THREE_MAN);
            Assert.AreEqual(1, _player.GetHand().GetOpenMelds().Count);
            Assert.AreEqual(LOW_CHII, _player.GetHand().GetOpenMelds()[0].GetMeldType());
        }

        [TestMethod]
        public void CallMidChii_CreatesNewMidChiiOpenMeldObject()
        {
            Setup();
            GeneratePotentialMidChiiCall(_player, _potentialCallQueue, THREE_MAN);
            _player.CallMidChii(THREE_MAN);
            Assert.AreEqual(1, _player.GetHand().GetOpenMelds().Count);
            Assert.AreEqual(MID_CHII, _player.GetHand().GetOpenMelds()[0].GetMeldType());
        }
        
        [TestMethod]
        public void CallHighChii_CreatesNewHighChiiOpenMeldObject()
        {
            Setup();
            GeneratePotentialHighChiiCall(_player, _potentialCallQueue, THREE_MAN);
            _player.CallHighChii(THREE_MAN);
            Assert.AreEqual(1, _player.GetHand().GetOpenMelds().Count);
            Assert.AreEqual(HIGH_CHII, _player.GetHand().GetOpenMelds()[0].GetMeldType());
        }
    }
}