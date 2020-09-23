using System.Collections.Generic;
using System.Linq;

namespace Exercises
{
    public partial class Exercises
    {
        /*
         * Given an array of non-empty strings, return a Dictionary<string, string> where for every different string in the array,
         * there is a key of its first character with the value of its last character.
         *
         * BeginningAndEnding(["code", "bug"]) → {"b": "g", "c": "e"}
         * BeginningAndEnding(["man", "moon", "main"]) → {"m": "n"}
         * BeginningAndEnding(["muddy", "good", "moat", "good", "night"]) → {"g": "d", "m": "t", "n": "t"}
         */
        public Dictionary<string, string> BeginningAndEnding(string[] words)
        {
            words = words.Distinct().ToArray();
            Dictionary<string, string> beginningAndEndDict = new Dictionary<string, string>(words.Length);

            foreach (string word in words)
                beginningAndEndDict[word[0].ToString()] = word[word.Length - 1].ToString();
            return beginningAndEndDict;
        }
    }
}
