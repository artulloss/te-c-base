using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Luck13Tests
    {
        /*
         Given an array of ints, return true if the array contains no 1's and no 3's.
         GetLucky([0, 2, 4]) → true
         GetLucky([1, 2, 3]) → false
         GetLucky([1, 2, 4]) → false
         */
        [TestMethod]
        public void Lucky13Test()
        {
            Lucky13 lucky13 = new Lucky13();
            Assert.IsTrue(lucky13.GetLucky(new[] {0, 2, 4}));
            Assert.IsFalse(lucky13.GetLucky(new[] {1, 2, 3}));
            Assert.IsFalse(lucky13.GetLucky(new[] {1, 2, 4}));
        }
    }
}