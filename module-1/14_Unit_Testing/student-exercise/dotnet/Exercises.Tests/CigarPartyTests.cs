using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class CigarPartyTests
    {
        /*
         When squirrels get together for a party, they like to have cigars. A squirrel party is successful
         when the number of cigars is between 40 and 60, inclusive. Unless it is the weekend, in which case 
         there is no upper bound on the number of cigars. Return true if the party with the given values is 
         successful, or false otherwise.
         haveParty(30, false) → false
         haveParty(50, false) → true
         haveParty(70, true) → true
         */
        [TestMethod]
        public void CigarPartyTest()
        {
            CigarParty cigarParty = new CigarParty();
            Assert.IsFalse(cigarParty.HaveParty(30, false));
            Assert.IsTrue(cigarParty.HaveParty(50, false));
            Assert.IsTrue(cigarParty.HaveParty(70, true));
        }
    }
}