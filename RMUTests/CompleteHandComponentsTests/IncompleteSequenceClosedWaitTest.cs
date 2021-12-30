using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Tiles;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class IncompleteSequenceClosedWaitTest
    {
        private ICompleteHandComponent _incompleteSequenceClosedWait;

        private void Setup()
        {
            _incompleteSequenceClosedWait = CreateCompleteHandComponent(new List<TileObject> { SevenMan(), NineMan() }, INCOMPLETE_SEQUENCE_CLOSED_WAIT);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceClosedWait()
        {
            Setup();
            Assert.IsNotNull(_incompleteSequenceClosedWait);
        }

        [TestMethod]
        public void GetComponentType_ReturnsIncompleteSequenceClosedWait()
        {
            Setup();
            Assert.AreEqual(INCOMPLETE_SEQUENCE_CLOSED_WAIT, _incompleteSequenceClosedWait.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsTaatsu()
        {
            Setup();
            Assert.AreEqual(TAATSU, _incompleteSequenceClosedWait.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsSevenMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(SevenMan(), _incompleteSequenceClosedWait.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListContainingSevenManAndNineMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(SevenMan(), _incompleteSequenceClosedWait.GetTiles()[0]));
            Assert.IsTrue(AreTilesEquivalent(NineMan(), _incompleteSequenceClosedWait.GetTiles()[1]));
        }
    }
}
