using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     Given an array of ints, return true if the array is length 1 or more, and the first element and
     the last element are equal.
     IsItTheSame([1, 2, 3]) → false
     IsItTheSame([1, 2, 3, 1]) → true
     IsItTheSame([1, 2, 1]) → true
     */
    [TestClass]
    public class SameFirstLastTests
    {
        [TestMethod]
        public void SameFirstLastTest()
        {
            SameFirstLast sameFirstLast = new SameFirstLast();
            Assert.IsFalse(sameFirstLast.IsItTheSame(new[] {1, 2, 3}));
            Assert.IsTrue(sameFirstLast.IsItTheSame(new[] {1, 2, 3, 1}));
            Assert.IsTrue(sameFirstLast.IsItTheSame(new[] {1, 2, 1}));
        }
    }
}