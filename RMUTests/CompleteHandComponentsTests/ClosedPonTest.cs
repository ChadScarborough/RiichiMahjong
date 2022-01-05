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
    public class ClosedPonTest
    {
        private ICompleteHandComponent _closedPon;

        private void Setup()
        {
            _closedPon = CreateCompleteHandComponent(new List<TileObject> { SouthWind(), SouthWind(), SouthWind() }, CLOSED_PON);
        }

        [TestMethod]
        public void CompleteHandComponentFactory_SuccessfullyCreatesClosedPon()
        {
            Setup();
            Assert.IsNotNull(_closedPon);
        }

        [TestMethod]
        public void GetComponentType_ReturnsClosedPon()
        {
            Setup();
            Assert.AreEqual(CLOSED_PON, _closedPon.GetComponentType());
        }

        [TestMethod]
        public void GetGeneralComponentType_ReturnsGroup()
        {
            Setup();
            Assert.AreEqual(GROUP, _closedPon.GetGeneralComponentType());
        }

        [TestMethod]
        public void GetTiles_ReturnsThreeSouthWindTiles()
        {
            Setup();
            for(int i = 0; i < 3; i++)
            {
                Assert.IsTrue(AreTilesEquivalent(SouthWind(), _closedPon.GetTiles()[i]));
            }
        }

        [TestMethod]
        public void GetLeadTile_ReturnsSouthWindTile()
        {
            Setup();
            Assert.IsTrue(AreTilesEquivalent(SouthWind(), _closedPon.GetLeadTile()));
        }

        [TestMethod]
        public void ThrowsException_WhenGivenAnIncorrectNumberOfTiles()
        {
            Exception exception = null;
            try
            {
                _closedPon = CreateCompleteHandComponent(new List<TileObject> { GREEN_DRAGON, GREEN_DRAGON }, CLOSED_PON);
            }
            catch(Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }

        [TestMethod]
        public void ThrowsException_WhenGivenAnInvalidTriplet()
        {
            Exception exception = null;
            try
            {
                _closedPon = CreateCompleteHandComponent(new List<TileObject> { GREEN_DRAGON, GREEN_DRAGON, RED_DRAGON }, CLOSED_PON);
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            Assert.IsNotNull(exception);
        }
    }
}
