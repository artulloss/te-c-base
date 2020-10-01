﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void MiddleWayTest()
        {
            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises();
            int[] result = loopsAndArrayExercises.MiddleWay(new[] {1, 2, 3}, new[] {4, 5, 6});
            CollectionAssert.AreEqual(new[] {2, 5}, result);
        }
        [TestMethod]
        public void MaxEnd3Test()
        {
            LoopsAndArrayExercises loopsAndArrayExercises = new LoopsAndArrayExercises();
            int[] result = loopsAndArrayExercises.MaxEnd3(new[] {1, 2, 3});
            CollectionAssert.AreEqual(new[] {3, 3, 3}, result);
        }
        
    }
}