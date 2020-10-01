using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableClasses.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestableClasses.Classes.Tests
{
    [TestClass()]
    public class LoopsAndArrayExercisesTests
    {
        //CollectionAssert
        //.AllItemsAreNotNull() - Looks at each item in actual collection for not null
        //.AllItemsAreUnique() - Checks for uniqueness among actual collection
        //.AreEqual() - Checks to see if two collections are equal (same order and quantity)
        //.AreEquilavent() - Checks to see if two collections have same element in same quantity, any order
        //.AreNotEqual() - Opposite of AreEqual
        //.AreNotEquilavent() - Opposite or AreEqualivent
        //.Contains() - Checks to see if collection contains a value/object

        //write tests for middleway
        [TestMethod]
        public void TestMiddleWay()
        {
            //middleWay([1, 2, 3], [4, 5, 6]) → [2, 5]
            //middleWay([7, 7, 7], [3, 8, 0]) → [7, 8]
            //middleWay([5, 2, 9], [1, 4, 5]) → [2, 4]

            LoopsAndArrayExercises lae = new LoopsAndArrayExercises();
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6 };
            int[] expected = { 2, 5 };

            int[] result = lae.MiddleWay(array1, array2);

            //AreEqual tests for same element in same order
            CollectionAssert.AreEqual(expected,result);

            //AreEquivalent tests for same elements in any order
            //{1,2,3} and {3,2,1} are equivalent but not equal

        }

        //write the test for MaxEnd3
        [TestMethod]
        public void TestMaxEnd3()
        {
            //maxEnd3([1, 2, 3]) → [3, 3, 3]
            //maxEnd3([11, 5, 9]) → [11, 11, 11]
            //maxEnd3([2, 11, 3]) → [3, 3, 3]

            LoopsAndArrayExercises lae = new LoopsAndArrayExercises();
            int[] array = { 1, 2, 3 };

            int[] result = lae.MaxEnd3(array);
            //int [] result = lae.MaxEnd3( new int[] {1,2,3}); anonymous array because i didn't save a reference to it

            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, result);

            result = lae.MaxEnd3(new int[] { 11, 5, 9 });
            CollectionAssert.AreEqual(new int[] { 11, 11, 11 }, result);

            result = lae.MaxEnd3(new int[] { 2, 11, 3 });
            CollectionAssert.AreEqual(new int[] { 3,3,3 }, result);
        }

    }
}