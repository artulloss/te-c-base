using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class StringBitsTests
    {
        /*
         Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo".
         GetBits("Hello") → "Hlo"	
         GetBits("Hi") → "H"	
         GetBits("Heeololeo") → "Hello"	
         */
        [TestMethod]
        public void StringBitTest()
        {
            StringBits stringBits = new StringBits();
            string result = stringBits.GetBits("Hello");
            Assert.AreEqual("Hlo", result);
            result = stringBits.GetBits("Hi");
            Assert.AreEqual("H", result);
            result = stringBits.GetBits("Heeololeo");
            Assert.AreEqual("Hello", result);
        }
    }
}