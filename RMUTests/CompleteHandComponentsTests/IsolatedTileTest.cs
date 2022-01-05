using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Hands.CompleteHands.CompleteHandComponents;
using static RMU.Hands.CompleteHands.CompleteHandComponents.CompleteHandComponentFactory;
using RMU.Tiles;
using static RMU.Globals.Enums;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Functions;

namespace RMUTests.CompleteHandComponentsTests
{
    [TestClass]
    public class IsolatedTileTest
    {
        private ICompleteHandComponent _isolatedTile;

        private void Setup()
        {
            _isolatedTile = CreateCompleteHandComponent(GreenDragon(), ISOLATED_TILE);
        }

        [TestMethod]
        public void FactorySuccessfullyCreates_IsolatedTile()
        {
            Setup();
            Assert.IsNotNull(_isolatedTile);
        }

        [TestMethod]
        public void GetComponentType_ReturnsIsolatedTile()
        {
            Setup();
            Assert.AreEqual(ISOLATED_TILE, _isolatedTile.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsTile()
        {
            Setup();
            Assert.AreEqual(TILE, _isolatedTile.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetLeadTile_ReturnsGreenDragon()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(GreenDragon(), _isolatedTile.GetLeadTile()));
        }

        [TestMethod]
        public void GetTiles_ReturnsListOfSizeOne_ContainingGreenDragon()
        {
            Setup();
            Assert.AreEqual(1, _isolatedTile.GetTiles().Count);
            Assert.IsTrue(AreTilesEquivalent(GREEN_DRAGON, _isolatedTile.GetTiles()[0]));
        }
    }
}
