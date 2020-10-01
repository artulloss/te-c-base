using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class NonStartTests
    {
        /*
         Given 2 strings, return their concatenation, except omit the first char of each. The strings will 
         be at least length 1.
         GetPartialString("Hello", "There") → "ellohere"
         GetPartialString("java", "code") → "avaode"	
         GetPartialString("shotl", "java") → "hotlava"	
         */
        [TestMethod]
        public void NonStartTest()
        {
            NonStart nonStart = new NonStart();
            Assert.AreEqual("ellohere", nonStart.GetPartialString("Hello", "There"));
            Assert.AreEqual("avaode", nonStart.GetPartialString("java", "code"));
            Assert.AreEqual("hotlava", nonStart.GetPartialString("shotl", "java"));
        }
    }
}