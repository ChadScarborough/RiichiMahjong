using Microsoft.VisualStudio.TestTools.UnitTesting;
using RMU.Shanten;

namespace RMUTests
{
    [TestClass]
    public class ShantenFormulaTest
    {

        [TestMethod]
        public void ThreeGroupsAndTwoPairs_ReturnsTenpai()
        {
            Assert.AreEqual(0, ShantenFormulas.CalculateStandardShanten(3,2,0)); 
        }

        [TestMethod]
        public void ThreeGroupsOnePairAndOneTaatsu_ReturnsTenpai()
        {
            Assert.AreEqual(0, ShantenFormulas.CalculateStandardShanten(3, 1, 1));
        }

        [TestMethod]
        public void OneGroupAndTwoPairs_ReturnsFourFromTenpai()
        {
            Assert.AreEqual(4, ShantenFormulas.CalculateStandardShanten(1, 2, 0));
        }

        [TestMethod]
        public void OneGroupAndOneTaatsu_ReturnsFiveFromTenpai()
        {
            Assert.AreEqual(5, ShantenFormulas.CalculateStandardShanten(1, 1, 0));
        }
    }
}
