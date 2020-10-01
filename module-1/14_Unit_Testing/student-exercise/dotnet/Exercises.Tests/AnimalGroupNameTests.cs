using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     * Given the name of an animal, return the name of a group of that animal
     * (e.g. "Elephant" -> "Herd", "Rhino" - "Crash").  
     * 
     * The animal name should be case insensitive so "elephant", "Elephant", and 
     * "ELEPHANT" should all return "herd". 
     * 
     * If the name of the animal is not found, null, or empty, return "unknown". 
     * 
     * Rhino -> Crash
     * Giraffe -> Tower
     * Elephant -> Herd
     * Lion -> Pride
     * Crow -> Murder
     * Pigeon -> Kit
     * Flamingo -> Pat
     * Deer -> Herd
     * Dog -> Pack
     * Crocodile -> Float
     *
     * GetHerd("giraffe") → "Tower"
     * GetHerd("") -> "unknown"         
     * GetHerd("walrus") -> "unknown"
     * GetHerd("Rhino") -> "Crash"
     * GetHerd("rhino") -> "Crash"
     * GetHerd("elephants") -> "unknown"
     * 
     */
    [TestClass]
    public class AnimalGroupNameTests
    {
        [TestMethod]
        public void AnimalGroupNameTest()
        {
            AnimalGroupName animalGroupName = new AnimalGroupName();
            Assert.AreEqual("Tower", animalGroupName.GetHerd("giraffe"));
            Assert.AreEqual("unknown", animalGroupName.GetHerd(""));
            Assert.AreEqual("unknown", animalGroupName.GetHerd("walrus"));
            Assert.AreEqual("Crash", animalGroupName.GetHerd("Rhino"));
            Assert.AreEqual("Crash", animalGroupName.GetHerd("rhino"));
            Assert.AreEqual("unknown", animalGroupName.GetHerd("elephants"));
        }
    }
}