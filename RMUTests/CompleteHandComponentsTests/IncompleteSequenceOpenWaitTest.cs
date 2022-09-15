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
    public class IncompleteSequenceOpenWaitTest
    {
        private ICompleteHandComponent _incompleteSequenceOpenWait;

        private void Setup()
        {
            _incompleteSequenceOpenWait = CreateCompleteHandComponent(new List<Tile> { SevenMan(), EightMan() }, INCOMPLETE_SEQUENCE_OPEN_WAIT);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IncompleteSequenceOpenWait()
        {
            Setup();
            Assert.IsNotNull(_incompleteSequenceOpenWait);
        }

        [TestMethod]
        public void GetComponentType_ReturnsIncompleteSequenceOpenWait()
        {
            Setup();
            Assert.AreEqual(INCOMPLETE_SEQUENCE_OPEN_WAIT, _incompleteSequenceOpenWait.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsTaatsu()
        {
            Setup();
            Assert.AreEqual(TAATSU, _incompleteSequenceOpenWait.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsSevenMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(SevenMan(), _incompleteSequenceOpenWait.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListContainingSevenManAndNineMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(SevenMan(), _incompleteSequenceOpenWait.GetTiles()[0]));
            Assert.IsTrue(AreTilesEquivalent(EightMan(), _incompleteSequenceOpenWait.GetTiles()[1]));
        }
    }
}
