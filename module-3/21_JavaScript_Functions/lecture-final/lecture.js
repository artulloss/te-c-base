/**
 * All named functions will have the function keyword and
 * a name followed by parentheses.
 * 
 * @returns {number} 1
 */
function returnOne() {
  return 1;
}

/**
 * Functions can also take parameters. These are just variables that are filled
 * in by whoever is calling the function.
 *
 * Also, we don't *have* to return anything from the actual function.
 *
 * @param {any} value the value to print to the console
 */
function printToConsole(value) {
  console.log(value);
}

/**
 * Write a function called multiplyTogether that multiplies two numbers together. But 
 * what happens if we don't pass a value in? What happens if the value is not a number?
 *
 * @param {number} firstParameter the first parameter to multiply
 * @param {number} secondParameter the second parameter to multiply
 */
function multiplyTogether(firstParameter, secondParameter) {
  return firstParameter * secondParameter; 
}

/**
 * This version makes sure that no parameters are ever missing. If
 * someone calls this function without parameters, we default the
 * values to 0. However, it is impossible in JavaScript to prevent
 * someone from calling this function with data that is not a number.
 * Call this function multiplyNoUndefined
 *
 * @param {number} [firstParameter=0] the first parameter to multiply
 * @param {number} [secondParameter=0] the second parameter to multiply
 */
function multiplyNoUndefined(firstParameter=0,secondParameter=0){
  return firstParameter * secondParameter;
}

 
/**
 * Functions can return earlier before the end of the function. This could be useful
 * in circumstances where you may not need to perform additional instructions or have to
 * handle a particular situation.
 * In this example, if the firstParameter is equal to 0, we return secondParameter times 2.
 * Observe what's printed to the console in both situations.
 * 
 * @param {number} firstParameter the first parameter
 * @param {number} secondParameter the second parameter
 */
function returnBeforeEnd(firstParameter, secondParameter) {
  console.log("This will always fire.");

  if (firstParameter == 0) {
    console.log("Returning secondParameter times two.");
    return secondParameter * 2;
  }

  //this only runs if firstParameter is NOT 0
  console.log("Returning firstParameter + secondParameter.");
  return firstParameter + secondParameter;
}

/**
 * Scope is defined as where a variable is available to be used.
 *
 * If a variable is declare inside of a block, it will only exist in
 * that block and any block underneath it. Once the block that the
 * variable was defined in ends, the variable disappears.
 */
function scopeTest() {
  // This variable will always be in scope in this function
  let inScopeInScopeTest = true;

  {
    // this variable lives inside this block and doesn't
    // exist outside of the block
    let scopedToBlock = inScopeInScopeTest;
  }

  // scopedToBlock doesn't exist here so an error will be thrown
  if (inScopeInScopeTest && scopedToBlock) {
    console.log("This won't print!");
  }
  
}

/**
 * Take the details of a person and create a English readable sentence to describe them.
 * 
 * @param {string} name the name of the person that we're describing
 * @param {number} age the age of the person 
 * @param {string[]} listOfQuirks list of quirks we'll print
 * @param {string} separator the string to separate the quirks by
 * @returns {string} the sentence description of the person
 */
function createSentenceFromUser(name, age, listOfQuirks = [], separator = ', ') {
  let description = `${name} is currently ${age} years old. Their quirks are: `;
  return description + listOfQuirks.join(separator);
}

/**
 * Takes an array and, using the power of anonymous functions, generates
 * their sum.
 *
 * @param {number[]} numbersToSum numbers to add up
 * @returns {number} sum of all the numbers
 */
function sumAllNumbers(numbersToSum) {
  /*
    let sum = 0;
    for (int i=0; i<numbersToSum.length;i++){
      sum += numbersToSum[i]; //add each number to the previous sum
    }
    return sum; 
  */

  return numbersToSum.reduce(
    /* add each number to the previous sum*/
    (sum,number) => {
       return sum + number //this gets assigned to the accumulator which is the sum
    }
  );
}

function sumAllNumbersNotUsingAnon(numbersToSum){
  return numbersToSum.reduce(addNumbers);
}
function addNumbers(accumulator,currentElement){
  return accumulator + currentElement; 
}

/**
 * Takes an array and returns a new array of only numbers that are
 * multiples of 3
 *
 * @param {number[]} numbersToFilter numbers to filter through
 * @returns {number[]} a new array with only those numbers that are
 *   multiples of 3
 */
function allDivisibleByThree(numbersToFilter) {
  return numbersToFilter.filter( (num) => {
     return num % 3===0; 
  } );

  /* this is logically equivalent
  let newList = [];
  for (let i=0;i<numbersToFilter.length;i++){
    let num = numbersToFilter[i];
    if (num%3===0)
    {
      newList.push(num);
    }
  }
  numbersToFilter=newList;
  */
}

function allDivisibleByThreeNonAnon(numbersToFilter){
  let filterMethod = isDivisibleByThree;
  return numbersToFilter.filter(filterMethod);
}

function isDivisibleByThree(number){
  return number % 3 === 0;
}


/* for every person in the parameter array that's an array of people, write the sentence createSentenceFromUser for them */
/**
 * 
 * @param {object[]} people the objects should all have a name and an age 
 */
function printPeopleDetails(people=[]){
  people.forEach( (person) => {
    console.log(createSentenceFromUser(person.name,person.age));
  });
}

function callForPrintForClass(){
  let classArray = [
    {
      name: "Evan",
      age: 20
    },
    {
      name: "Brian",
      age: 30
    },
    {
     name: "Birttney",
     age: 40
    }
  ];
  printPeopleDetails(classArray);
  console.log('Average age: ',getAverageAge(classArray));
}

/*function to add sales tax to every item in my array */
function addSalesTax(prices=[],taxPercent=.06) {
  return prices.map(
    (price) => {
      return price * ( 1+ taxPercent);
    }
  )
}

/*what is the product of all of the numbers in an array?*/
function getProduct(numbers){
  return numbers.reduce( (accumulator,current) => 
      accumulator * current, 0
  );
}

/*get the average age of all of the people*/
function getAverageAge(people=[]){
  let sumAge =  people.reduce (
     (accumulator,currentPerson) => {return accumulator+currentPerson.age;},0);
  return sumAge / people.length; 
}


/* create an array of people out of an array of names and make them all be 21*/
function makePeople(names=[]){
  return names.map( (currentName) => {
    let object = { name: currentName, age: 21};
    return object;
  })

  
  let peopleArray=[];
  names.forEach( (currentName)=> {
    let object = {name: currentName, age: 21};
    peopleArray.push(object);
  })
  return peopleArray; 
}