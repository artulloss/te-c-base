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

        [TestMethod]
        public void MakeAbbaTest()
        {
            StringExercises stringExercises = new StringExercises();
            string result = stringExercises.MakeAbba("Hi", "Bye");
            Assert.AreEqual("HiByeByeHi", result);
            result = stringExercises.MakeAbba("Yo", "Alice");
            Assert.AreEqual("YoAliceAliceYo", result);
            result = stringExercises.MakeAbba("What", "Up");
            Assert.AreEqual("WhatUpUpWhat", result);
        }

        [TestMethod]
       public void MakeOutWordTest()
         {
            // Arrange
            StringExercises stringExercises = new StringExercises();
            // Act
            string result = stringExercises.MakeOutWord("<<>>", "Yay");
            // Assert
            Assert.AreEqual("<<Yay>>", result);
        }
       
       [TestMethod]
       public void MakeOutWordTestNull()
       {
           // Arrange
           StringExercises stringExercises = new StringExercises();
           // Act
           stringExercises.MakeOutWord(null, null);
       }

       [TestMethod]
       public void FirstTwoTest()
       {
           StringExercises stringExercises = new StringExercises();
           string result = stringExercises.FirstTwo("Hello World"); 
           Assert.AreEqual("He", result);
           result = stringExercises.FirstTwo("F");
           Assert.AreEqual("F", result);
       }
        
        //Assert
        //.AreEqual() - compares expected and actual value for equality
        //.AreSame() - verifies two object variables refer to same object
        //.AreNotSame() - verifies two object variables refer to different objects
        //.Fail() - fails without checking conditions
        //.IsFalse()
        //.IsTrue()
        //.IsNotNull()
        //.IsNull()


        
    }
}