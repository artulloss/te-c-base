using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]
    public class WordCountTests
    {
        /*
         * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the 
         * number of times that string appears in the array.
         * 
         * ** A CLASSIC **
         * 
         * GetCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
         * GetCount(["a", "b", "a", "c", "b"]) → {"a": 2, "b": 2, "c": 1}
         * GetCount([]) → {}
         * GetCount(["c", "b", "a"]) → {"c": 1, "b": 1, "a": 1}
         * 
         */
        [TestMethod]
        public void WordCountTest()
        {
            WordCount wordCount = new WordCount();
            Dictionary<string, int> result = wordCount.GetCount(new[] {"ba", "ba", "black", "sheep"});
            CollectionAssert.AreEqual
                (new Dictionary<string, int> {{"ba", 2}, {"black", 1}, {"sheep", 1}}, result);
            result = wordCount.GetCount(new[] {"a", "b", "a", "c", "b"});
            CollectionAssert.AreEqual
                (new Dictionary<string, int> {{"a", 2}, {"b", 2}, {"c", 1}}, result);
            result = wordCount.GetCount(new string[] {});
            CollectionAssert.AreEqual
                (new Dictionary<string, int>(), result);
            result = wordCount.GetCount(new[] {"c", "b", "a"});
            CollectionAssert.AreEqual
                (new Dictionary<string, int>() { {"c", 1}, {"b", 1}, {"a", 1} }, result);
        }
    }
}