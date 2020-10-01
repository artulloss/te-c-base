using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     Given an array of ints length 3, figure out which is larger between the first and last elements 
     in the array, and set all the other elements to be that value. Return the changed array.
     MakeArray([1, 2, 3]) → [3, 3, 3]
     MakeArray([11, 5, 9]) → [11, 11, 11]
     MakeArray([2, 11, 3]) → [3, 3, 3]
     */
    [TestClass]
    public class MaxEnd3Tests
    {
        [TestMethod]
        public void MaxEnd3Test()
        {
            MaxEnd3 maxEnd3 = new MaxEnd3();
            CollectionAssert.AreEqual(new[] {3, 3, 3}, maxEnd3.MakeArray(new[] {1, 2, 3}));
            CollectionAssert.AreEqual(new[] {11, 11, 11}, maxEnd3.MakeArray(new[] {11, 5, 9}));
            CollectionAssert.AreEqual(new[] {3, 3, 3}, maxEnd3.MakeArray(new[] {2, 11, 3}));
        }
    }
}