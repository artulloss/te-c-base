/*
1. **iqTest** Bob is preparing to pass an IQ test. The most frequent task in this test 
    is to find out which one of the given numbers differs from the others. Bob observed
    that one number usually differs from the others in evenness. Help Bob — to check his 
    answers, he needs a program that among the given numbers finds one that is different in 
    evenness, and return the position of this number. _Keep in mind that your task is to help 
    Bob solve a real IQ test, which means indexes of the elements start from 1 (not 0)_

		iqTest("2 4 7 8 10") → 3 //third number is odd, while the rest are even
		iqTest("1 2 1 1") → 2 // second number is even, while the rest are odd
		iqTest("") → 0 // there are no numbers in the given set
        iqTest("2 2 4 6") → 0 // all numbers are even, therefore there is no position of an odd number
*/

const iqTest = (str) => {
  let index = 0;
  ar = str.split(" ");
  let evenAr = ar.filter((v) => v % 2 === 0);
  let oddAr = ar.filter((v) => v % 2 === 1);
  if (evenAr.length > oddAr.length && oddAr.length !== 0) {
    index = ar.findIndex((e) => e === oddAr[0]) + 1;
  } else if (evenAr.length < oddAr.length && evenAr.length !== 0) {
    index = ar.findIndex((e) => e === evenAr[0]) + 1;
  }
  return index;
};
/*
2. **titleCase** Write a function that will convert a string into title case, given an optional 
    list of exceptions (minor words). The list of minor words will be given as a string with each 
    word separated by a space. Your function should ignore the case of the minor words string -- 
    it should behave in the same way even if the case of the minor word string is changed.


* First argument (required): the original string to be converted.
* Second argument (optional): space-delimited list of minor words that must always be lowercase
except for the first word in the string. The JavaScript tests will pass undefined when this 
argument is unused.

		titleCase('a clash of KINGS', 'a an the of') // should return: 'A Clash of Kings'
		titleCase('THE WIND IN THE WILLOWS', 'The In') // should return: 'The Wind in the Willows'
        titleCase('the quick brown fox') // should return: 'The Quick Brown Fox'
*/

/**
 *
 * @param {string} title The title
 * @param {string} words The words to lowercase, except for first word
 */
const titleCase = (title, words = "") => {
  titleArray = title.split(" ");
  wordsArray = words.split(" ");
  wordsArray = wordsArray.map((w) => w.toLowerCase());
  let first = true;
  return titleArray
    .map((w) => {
      if (wordsArray.includes(w.toLowerCase()) && !first) {
        return w.toLowerCase();
      }
      first = false;
      return w.substr(0, 1).toUpperCase() + w.substr(1).toLowerCase();
    })
    .join(" ");
};
