using static RMU.Globals.Functions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static RMU.Globals.StandardTileList;
using static RMU.Globals.Enums;
using RMU.Tiles;

namespace RMUTests
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInFirstPosition()
        {
            Assert.AreEqual(0, MinOfEight(0, 1, 1, 1, 1, 1, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInSecondPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 0, 1, 1, 1, 1, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInThirdPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 0, 1, 1, 1, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInFourthPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 1, 0, 1, 1, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInFifthPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 1, 1, 0, 1, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInSixthPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 1, 1, 1, 0, 1, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInSeventhPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 1, 1, 1, 1, 0, 1));
        }

        [TestMethod]
        public void MinOfEight_ReturnsZero_WhenZeroIsInEighthPosition()
        {
            Assert.AreEqual(0, MinOfEight(1, 1, 1, 1, 1, 1, 1, 0));
        }

        [TestMethod]
        public void MinOfThree_ReturnsZero_WhenZeroIsInFirstPosition()
        {
            Assert.AreEqual(0, MinOfThree(0, 1, 1));
        }

        [TestMethod]
        public void MinOfThree_ReturnsZero_WhenZeroIsInSecondPosition()
        {
            Assert.AreEqual(0, MinOfThree(1, 0, 1));
        }

        [TestMethod]
        public void MinOfThree_ReturnsZero_WhenZeroIsInThirdPosition()
        {
            Assert.AreEqual(0, MinOfThree(1, 1, 0));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsTrue_WhenGivenThreeIdenticalTiles()
        {
            Assert.IsTrue(AreTilesEquivalent(FIVE_MAN, FIVE_MAN, FIVE_MAN));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenTwoIdenticalTiles_AndOneTileOfADifferentSuit()
        {
            Assert.IsFalse(AreTilesEquivalent(FIVE_MAN, FIVE_MAN, FIVE_SOU));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenTwoIdenticalTiles_AndOneTileOfADifferentValue()
        {
            Assert.IsFalse(AreTilesEquivalent(FIVE_MAN, FIVE_MAN, SIX_MAN));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenTwoIdenticalTiles_AndANullTile()
        {
            Assert.IsFalse(AreTilesEquivalent(THREE_MAN, null, THREE_MAN));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsTrue_WhenGivenTwoIdenticalTiles()
        {
            Assert.IsTrue(AreTilesEquivalent(FIVE_MAN, FIVE_MAN));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenTwoTilesOfDifferentSuits()
        {
            Assert.IsFalse(AreTilesEquivalent(FIVE_MAN, FIVE_SOU));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenANullTile()
        {
            Assert.IsFalse(AreTilesEquivalent(THREE_MAN, null));
        }

        [TestMethod]
        public void AreTilesEquivalent_ReturnsFalse_WhenGivenTwoTilesOfDifferentValues()
        {
            Assert.IsFalse(AreTilesEquivalent(FIVE_MAN, SIX_MAN));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsTrue_WhenGivenEastWindAndEastTile()
        {
            Assert.IsTrue(AreWindsEquivalent(EastWind(), EAST));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsTrue_WhenGivenSouthWindAndSouthTile()
        {
            Assert.IsTrue(AreWindsEquivalent(SouthWind(), SOUTH));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsTrue_WhenGivenWestWindAndWestTile()
        {
            Assert.IsTrue(AreWindsEquivalent(WestWind(), WEST));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsTrue_WhenGivenNorthWindAndNorthTile()
        {
            Assert.IsTrue(AreWindsEquivalent(NorthWind(), NORTH));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsFalse_WhenGivenANonWindTile()
        {
            Assert.IsFalse(AreWindsEquivalent(ONE_MAN, EAST));
        }

        [TestMethod]
        public void AreWindsEquivalent_ReturnsFalse_WhenGivenANonMatchingWindAndTile()
        {
            Assert.IsFalse(AreWindsEquivalent(EAST_WIND, SOUTH));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsTrue_WhenGivenGreenDragonAndGreenTile()
        {
            Assert.IsTrue(AreDragonsEquivalent(GREEN_DRAGON, GREEN));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsTrue_WhenGivenRedDragonAndRedTile()
        {
            Assert.IsTrue(AreDragonsEquivalent(RED_DRAGON, RED));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsTrue_WhenGivenWhiteDragonAndWhiteTile()
        {
            Assert.IsTrue(AreDragonsEquivalent(WHITE_DRAGON, WHITE));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsFalse_WhenGivenANonDragonTile()
        {
            Assert.IsFalse(AreDragonsEquivalent(TWO_PIN, RED));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsFalse_WhenGivenANullTile()
        {
            Assert.IsFalse(AreDragonsEquivalent(null, WHITE));
        }

        [TestMethod]
        public void AreDragonsEquivalent_ReturnsFalse_WhenGivenANonMatchingDragonAndTile()
        {
            Assert.IsFalse(AreDragonsEquivalent(GREEN_DRAGON, RED));
        }

        [TestMethod]
        public void GetTileAbove_ReturnsTileOfSameSuit_AndValueOneAboveInputTile()
        {
            TileObject inputTile = OneMan();
            Assert.IsTrue(AreTilesEquivalent(TWO_MAN, GetTileAbove(inputTile)));
        }

        [TestMethod]
        public void GetTileAbove_ReturnsNull_WhenGivenDragonTile()
        {
            TileObject inputTile = RedDragon();
            Assert.IsNull(GetTileAbove(inputTile));
        }

        [TestMethod]
        public void GetTileAbove_ReturnsNull_WhenGivenWindTile()
        {
            TileObject inputTile = WestWind();
            Assert.IsNull(GetTileAbove(inputTile));
        }

        [TestMethod]
        public void GetTileAboveReturnsNull_WhenGivenNumberTileWithValueNine()
        {
            TileObject inputTile = NinePin();
            Assert.IsNull(GetTileAbove(inputTile));
        }

        [TestMethod]
        public void GetTileAboveReturnsNull_WhenGivenNullTile()
        {
            Assert.IsNull(GetTileAbove(null));
        }

        [TestMethod]
        public void GetTileBelow_ReturnsTileOfSameSuit_AndValueOneBelowInputTile()
        {
            TileObject inputTile = TwoSou();
            Assert.IsTrue(AreTilesEquivalent(OneSou(), GetTileBelow(inputTile)));
        }

        [TestMethod]
        public void GetTileBelow_ReturnsNull_WhenGivenDragonTileAsInput()
        {
            TileObject inputTile = WhiteDragon();
            Assert.IsNull(GetTileBelow(inputTile));
        }

        [TestMethod]
        public void GetTileBelow_ReturnsNull_WhenGivenWindTileAsInput()
        {
            TileObject inputTile = SouthWind();
            Assert.IsNull(GetTileBelow(inputTile));
        }

        [TestMethod]
        public void GetTileBelow_ReturnsNull_WhenGivenNumberTileWithValueOne()
        {
            TileObject inputTile = OnePin();
            Assert.IsNull(GetTileBelow(inputTile));
        }

        [TestMethod]
        public void GetTileBelowReturnsNull_WhenGivenNullTile()
        {
            Assert.IsNull(GetTileBelow(null));
        }

        [TestMethod]
        public void GetTileTwoAbove_ReturnsTileOfSameSuit_AndValueTwoAboveInputTile()
        {
            TileObject inputTile = OneMan();
            Assert.IsTrue(AreTilesEquivalent(THREE_MAN, GetTileTwoAbove(inputTile)));
        }

        [TestMethod]
        public void GetTileTwoAbove_ReturnsNull_WhenGivenDragonTile()
        {
            TileObject inputTile = RedDragon();
            Assert.IsNull(GetTileTwoAbove(inputTile));
        }

        [TestMethod]
        public void GetTileTwoAbove_ReturnsNull_WhenGivenWindTile()
        {
            TileObject inputTile = WestWind();
            Assert.IsNull(GetTileTwoAbove(inputTile));
        }

        [TestMethod]
        public void GetTwoTileAboveReturnsNull_WhenGivenNumberTileWithValueNine()
        {
            TileObject inputTile = NinePin();
            Assert.IsNull(GetTileTwoAbove(inputTile));
        }

        [TestMethod]
        public void GetTwoTileAboveReturnsNull_WhenGivenNumberTileWithValueEight()
        {
            TileObject inputTile = EightPin();
            Assert.IsNull(GetTileTwoAbove(inputTile));
        }

        [TestMethod]
        public void GetTileTwoAboveReturnsNull_WhenGivenNullTile()
        {
            Assert.IsNull(GetTileTwoAbove(null));
        }

        [TestMethod]
        public void GetTileTwoBelow_ReturnsTileOfSameSuit_AndValueTwoBelowInputTile()
        {
            TileObject inputTile = ThreeSou();
            Assert.IsTrue(AreTilesEquivalent(OneSou(), GetTileTwoBelow(inputTile)));
        }

        [TestMethod]
        public void GetTileTwoBelow_ReturnsNull_WhenGivenDragonTileAsInput()
        {
            TileObject inputTile = WhiteDragon();
            Assert.IsNull(GetTileTwoBelow(inputTile));
        }

        [TestMethod]
        public void GetTileTwoBelow_ReturnsNull_WhenGivenWindTileAsInput()
        {
            TileObject inputTile = SouthWind();
            Assert.IsNull(GetTileTwoBelow(inputTile));
        }

        [TestMethod]
        public void GetTileTwoBelow_ReturnsNull_WhenGivenNumberTileWithValueOne()
        {
            TileObject inputTile = OnePin();
            Assert.IsNull(GetTileTwoBelow(inputTile));
        }

        [TestMethod]
        public void GetTileTwoBelow_ReturnsNull_WhenGivenNumberTileWithValueTwo()
        {
            TileObject inputTile = TwoPin();
            Assert.IsNull(GetTileTwoBelow(inputTile));
        }

        [TestMethod]
        public void GetTileTwoBelowReturnsNull_WhenGivenNullTile()
        {
            Assert.IsNull(GetTileTwoBelow(null));
        }
    }
}
