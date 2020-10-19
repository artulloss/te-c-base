using Assessment.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assessment.Tests
{
    [TestClass]
    public class CarTests
    {
        [TestMethod]
        public void AgeTest() {
            Car car = new Car(2010, "Audi R8", false);
            Assert.AreEqual(10, car.Age);
            
            car = new Car(2019, "Audi R8", false);
            Assert.AreEqual(1, car.Age);
        }
        
        [TestMethod]
        public void ECheckTest() {
            Car carEven = new Car(2010, "Audi R8", false);
            Car carOdd = new Car(2011, "Audi R8", false);
            Car carNew = new Car(2020, "Audi R8", false);
            Car carClassic = new Car(2020, "Audi R8", true);

            Assert.IsTrue(carEven.NeedsECheck(2020));
            Assert.IsFalse(carEven.NeedsECheck(2019));

            Assert.IsTrue(carOdd.NeedsECheck(2019));
            Assert.IsFalse(carOdd.NeedsECheck(2020));

            Assert.IsFalse(carNew.NeedsECheck(2020));
            Assert.IsFalse(carNew.NeedsECheck(2019));

            Assert.IsFalse(carClassic.NeedsECheck(2020));
            Assert.IsFalse(carClassic.NeedsECheck(2019));
        }
    }
}
