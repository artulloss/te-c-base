using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     Given a string and a non-negative int n, we'll say that the front of the string is the first 3 chars, or 
     whatever is there if the string is less than length 3. Return n copies of the front;
     frontTimes("Chocolate", 2) → "ChoCho"	
     frontTimes("Chocolate", 3) → "ChoChoCho"	
     frontTimes("Abc", 3) → "AbcAbcAbc"	
     */
    [TestClass]
    public class FrontTimesTests
    {
        [TestMethod]
        public void FrontTimesTest()
        {
            FrontTimes frontTimes = new FrontTimes();
            Assert.AreEqual("ChoCho", frontTimes.GenerateString("Chocolate", 2));
            Assert.AreEqual("ChoChoCho", frontTimes.GenerateString("Chocolate", 3));
            Assert.AreEqual("AbcAbcAbc", frontTimes.GenerateString("Abc", 3));
        }
    }
}