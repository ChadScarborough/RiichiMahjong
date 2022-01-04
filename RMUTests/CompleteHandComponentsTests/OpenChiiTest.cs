using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hand.CompleteHands.CompleteHandComponents;
using static RMU.Hand.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Calls.CreateMeldBehaviours;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class OpenChiiTest
    {
        private ICompleteHandComponent _openChii;

        private void Setup()
        {
            OpenMeld oc = new OpenMeld(MID_CHII, FourMan());
            _openChii = CreateCompleteHandComponent(oc);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_OpenChii()
        {
            Setup();
            Assert.IsNotNull(_openChii);
        }

        [TestMethod]
        public void GetComponentType_ReturnsOpenChii()
        {
            Setup();
            Assert.AreEqual(OPEN_CHII, _openChii.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            Setup();
            Assert.AreEqual(GROUP, _openChii.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsThreeMan()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(THREE_MAN, _openChii.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListOfSizeThree_ContainingThreeFourAndFiveMan()
        {
            Setup();
            Assert.AreEqual(3, _openChii.GetTiles().Count);
            Assert.IsTrue(AreTilesEquivalent(THREE_MAN, _openChii.GetTiles()[0]));
            Assert.IsTrue(AreTilesEquivalent(FOUR_MAN, _openChii.GetTiles()[1]));
            Assert.IsTrue(AreTilesEquivalent(FIVE_MAN, _openChii.GetTiles()[2]));
        }
    }
}
