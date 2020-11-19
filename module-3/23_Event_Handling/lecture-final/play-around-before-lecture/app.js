


let myButton = document.getElementById('the_button');
myButton.addEventListener('click',showButtonAlert) // no parentheses

function showButtonAlert(event){
    alert('You clicked button' + event.target);
}

let myDiv  = document.querySelector('.the-div');
myDiv.addEventListener('mouseover',(event)=>{
   event.target.classList.remove('blue');
   event.target.classList.add('red');
   //i can only remove NAMED function event listeners
   myButton.removeEventListener('click',showButtonAlert);//my button will stop working once the user has moused over the div
});
myDiv.addEventListener('mouseout',(event)=>{
    event.target.classList.remove('red');
    event.target.classList.add('blue');
    event.stopPropagation();
 });


 const groceryButton = document.getElementById('grocery-button');
 groceryButton.addEventListener( 'click',(event)=>{
     //get reference to ul, create a li, and append as a child
     const groceryList = document.getElementById('the-ul');
     const newGrocery = document.createElement('li');
     newGrocery.innerText='coffee';
     groceryList.appendChild(newGrocery);
 })

 const justTheOneLink = document.querySelector('a');
 justTheOneLink.addEventListener('click',(event)=>{
     event.preventDefault();
     //alert("you may not leave this page!");
 })