using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Tiles;
using RMU.Wall;

namespace RMUTests
{
    [TestClass]
    public class WallTest
    {
        private Wall _wall;

        [TestMethod]
        public void FourPlayerWallNoRedFives_InitializesWith136Tiles()
        {
            _wall = new FourPlayerWallNoRedFives();
            Assert.AreEqual(136, _wall.GetSize());
        }

        [TestMethod]
        public void FourPlayerWallThreeRedFives_InitializesWith136Tiles()
        {
            _wall = new FourPlayerWallThreeRedFives();
            Assert.AreEqual(136, _wall.GetSize());
        }

        [TestMethod]
        public void FourPlayerWallFourRedFives_InitializesWith136Tiles()
        {
            _wall = new FourPlayerWallFourRedFives();
            Assert.AreEqual(136, _wall.GetSize());
        }

        [TestMethod]
        public void ThreePlayerWallNoRedFives_InitializesWith108Tiles()
        {
            _wall = new ThreePlayerWallNoRedFives();
            Assert.AreEqual(108, _wall.GetSize());
        }

        [TestMethod]
        public void ThreePlayerWallTwoRedFive_InitializesWith108Tiles()
        {
            _wall = new ThreePlayerWallTwoRedFives();
            Assert.AreEqual(108, _wall.GetSize());
        }

        [TestMethod]
        public void GetWallTilesMethod_ReturnsListOfTilesInWall()
        {
            _wall = new FourPlayerWallThreeRedFives();
            Assert.AreEqual(136, _wall.GetWallTiles().Count);
        }

        [TestMethod]
        public void FourPlayerWallNoRedFives_ContainsNoRedFives()
        {
            int redFives = 0;
            _wall = new FourPlayerWallNoRedFives();
            foreach (TileObject tile in _wall.GetWallTiles())
            {
                if (tile.IsRedFive())
                {
                    redFives++;
                }
            }
            Assert.AreEqual(0, redFives);
        }

        [TestMethod]
        public void FourPlayerWallThreeRedFives_ContainsThreeRedFives()
        {
            int redFives = 0;
            _wall = new FourPlayerWallThreeRedFives();
            foreach (TileObject tile in _wall.GetWallTiles())
            {
                if (tile.IsRedFive())
                {
                    redFives++;
                }
            }
            Assert.AreEqual(3, redFives);
        }

        [TestMethod]
        public void FourPlayerWallFourRedFives_ContainsFourRedFives()
        {
            int redFives = 0;
            _wall = new FourPlayerWallFourRedFives();
            foreach (TileObject tile in _wall.GetWallTiles())
            {
                if (tile.IsRedFive())
                {
                    redFives++;
                }
            }

            Assert.AreEqual(4, redFives);
        }

        [TestMethod]
        public void ThreePlayerWallNoRedFives_ContainsNoRedFives()
        {
            int redFives = 0;
            _wall = new ThreePlayerWallNoRedFives();
            foreach (TileObject tile in _wall.GetWallTiles())
            {
                if (tile.IsRedFive())
                {
                    redFives++;
                }
            }

            Assert.AreEqual(0, redFives);
        }

        [TestMethod]
        public void ThreePlayerWallTwoRedFives_ContainsTwoRedFives()
        {
            int redFives = 0;
            _wall = new ThreePlayerWallTwoRedFives();
            foreach (TileObject tile in _wall.GetWallTiles())
            {
                if (tile.IsRedFive())
                {
                    redFives++;
                }
            }
            Assert.AreEqual(2, redFives);
        }
    }
}
