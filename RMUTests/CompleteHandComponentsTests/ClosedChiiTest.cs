using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class ClosedChiiTest
    {
        private ICompleteHandComponent _closedChii;

        [TestMethod]
        public void ComponentFactorySuccessfullyCreatesClosedChiiComponent()
        {
            _closedChii = CreateCompleteHandComponent(new List<Tile> { TwoMan(), ThreeMan(), FourMan() }, CLOSED_CHII);
            Assert.IsNotNull(_closedChii);
        }

        [TestMethod]
        public void GetComponentType_ReturnsClosedChii()
        {
            _closedChii = CreateCompleteHandComponent(new List<Tile> { ThreePin(), FourPin(), FivePin() }, CLOSED_CHII);
            Assert.AreEqual(CLOSED_CHII, _closedChii.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            _closedChii = CreateCompleteHandComponent(new List<Tile> { ThreePin(), FourPin(), FivePin() }, CLOSED_CHII);
            Assert.AreEqual(GROUP, _closedChii.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsLowestTileInSequence()
        {
            _closedChii = CreateCompleteHandComponent(new List<Tile> { ThreePin(), FourPin(), FivePin() }, CLOSED_CHII);
            Assert.IsTrue(AreTilesEquivalent(THREE_PIN, _closedChii.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsSameListOfTilesAsInput()
        {
            List<Tile> inputList = new List<Tile> { FiveSou(), SixSou(), SevenSou() };
            _closedChii = CreateCompleteHandComponent(inputList, CLOSED_CHII);
            for(int i = 0; i < 3; i++)
            {
                Assert.IsTrue(AreTilesEquivalent(inputList[i], _closedChii.GetTiles()[i]));
            }
        }

        [TestMethod]
        public void ThrowsException_WhenGivenAnIncorrectNumberOfTiles()
        {
            Exception ex = null;
            List<Tile> inputList = new List<Tile> { FourMan(), FiveMan() };
            try
            {
                _closedChii = CreateCompleteHandComponent(inputList, CLOSED_CHII);
            }
            catch(Exception exception)
            {
                ex = exception;
            }
            Assert.IsNotNull(ex);
        }

        [TestMethod]
        public void ThrowException_WhenGivenAnInvalidSequence()
        {
            Exception ex = null;
            List<Tile> inputList = new List<Tile> { FourMan(), FiveMan(), SevenMan() };
            try
            {
                _closedChii = CreateCompleteHandComponent(inputList, CLOSED_CHII);
            }
            catch (Exception exception)
            {
                ex = exception;
            }
            Assert.IsNotNull(ex);
        }
    }
}
