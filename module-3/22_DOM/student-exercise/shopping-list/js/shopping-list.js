// add pageTitle
const title = "My Shopping List";
// add groceries
const groceries = [
  "Rice",
  "Noodles",
  "Egg",
  "Steak",
  "Bacon",
  "Mushrooms",
  "Panko",
  "Parsley",
  "Basil",
  "Apples",
];
/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  document.getElementById("title").innerText = title;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {
  const ulGroceries = document.getElementById("groceries");
  for (grocerie of groceries) {
    const liGrocerie = document.createElement("li");
    liGrocerie.innerText = grocerie;
    ulGroceries.appendChild(liGrocerie);
  }
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
  const elements = document.querySelectorAll("#groceries li");
  elements.forEach((e) => (e.className = "completed"));
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener("DOMContentLoaded", () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector(".btn");
  button.addEventListener("click", markCompleted);
});
