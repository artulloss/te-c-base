using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class Less20Tests
    {
        /*
         Return true if the given non-negative number is 1 or 2 less than a multiple of 20. So for example 38 
         and 39 return true, but 40 returns false. 
         (Hint: Think "mod".)
         less20(18) → true
         less20(19) → true
         less20(20) → false
         */
        [TestMethod]
        public void Less20Test()
        {
            Less20 less20 = new Less20();
            Assert.IsTrue(less20.IsLessThanMultipleOf20(18));
            Assert.IsTrue(less20.IsLessThanMultipleOf20(19));
            Assert.IsFalse(less20.IsLessThanMultipleOf20(20));
        }
    }
}