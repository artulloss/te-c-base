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
    public class StringExercisesTests
    {
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()


        [TestMethod]
        public void MakeAbbaTest()
        {
            //makeAbba("Hi", "Bye") → "HiByeByeHi"
            //makeAbba("Yo", "Alice") → "YoAliceAliceYo"
            //makeAbba("What", "Up") → "WhatUpUpWhat"

            //Arrange
            StringExercises stringExercises = new StringExercises();

            //Act
            string result = stringExercises.MakeAbba("Hi", "Bye");

            //Assert
            Assert.AreEqual("HiByeByeHi", result);

            Assert.AreEqual("YoAliceAliceYo", stringExercises.MakeAbba("Yo", "Alice"));


        }

        [TestMethod]
        public void CompareFloatsAndDoublesExample()
        {
            //when you're comparing doubles, since they are imprecise
            float f = .1F + .2F;
            Assert.AreEqual(.3, f, .001); //as long as they are within .001, count as equal

            double d = .1 + .2;
            Assert.AreEqual(.3, d, .001); //as long as they are within .001, count as equal
        }

        [TestMethod]
        public void TestMakeOutWord()
        {
            //makeOutWord("<<>>", "Yay") → "<<Yay>>"
            //makeOutWord("<<>>", "WooHoo") → "<<WooHoo>>"
            //makeOutWord("[[]]", "word") → "[[word]]"

            //Arrange
            StringExercises stringExercises = new StringExercises();

            //Act 
            string result = stringExercises.MakeOutWord("<<>>", "Yay");

            //Assert
            Assert.AreEqual("<<Yay>>", result, "d'oh");
        }

        [TestMethod]
        public void TestMakeOutWordWithNull()
        {
            //arrange
            StringExercises stringExercises = new StringExercises();
            //act
            string result = stringExercises.MakeOutWord(null, null);

            //assert
            Assert.IsNull(result);
        }

        //write some tests for FirstTwo method
        [TestMethod]
        public void TestFirstTwo()
        {
            //firstTwo("Hello") → "He"
            //firstTwo("abcdefg") → "ab"
            //firstTwo("ab") → "ab"
            StringExercises stringExercises = new StringExercises();
            Assert.AreEqual("He", stringExercises.FirstTwo("Hello"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("abcdefg"));
            Assert.AreEqual("ab", stringExercises.FirstTwo("ab"));
        }

        [TestMethod]
        public void TestFirstTwoWithShortStrings()
        {
            StringExercises stringExercises = new StringExercises();
            Assert.AreEqual("a", stringExercises.FirstTwo("a"));
            Assert.AreEqual("", stringExercises.FirstTwo(""));
            Assert.AreEqual(null, stringExercises.FirstTwo(null));
        }
    }
}