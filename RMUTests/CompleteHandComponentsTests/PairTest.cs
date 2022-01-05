using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using static RMU.Globals.Functions;
using RMU.Tiles;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class PairTest
    {
        private ICompleteHandComponent _pair;

        private void Setup()
        {
            _pair = CreateCompleteHandComponent(new List<TileObject> { OneSou(), OneSou() }, PAIR_COMPONENT);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_Pair()
        {
            Setup();
            Assert.IsNotNull(_pair);
        }

        [TestMethod]
        public void GetComponentType_ReturnsPairComponent()
        {
            Setup();
            Assert.AreEqual(PAIR_COMPONENT, _pair.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsPair()
        {
            Setup();
            Assert.AreEqual(PAIR, _pair.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsOneSou()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(ONE_SOU, _pair.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListOfSizeTwo_ContainingTwoOneSouTiles()
        {
            Setup();
            Assert.AreEqual(2, _pair.GetTiles().Count);
            Assert.IsTrue(AreTilesEquivalent(ONE_SOU, _pair.GetTiles()[0]));
            Assert.IsTrue(AreTilesEquivalent(ONE_SOU, _pair.GetTiles()[1]));
        }
    }
}
