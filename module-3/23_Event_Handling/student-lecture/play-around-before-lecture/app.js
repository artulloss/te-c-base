let myButton = document.getElementById('the_button');
myButton.addEventListener('click',showButtonAlert) // no parentheses

function showButtonAlert(event){
    alert('You clicked button' + event.target);
}

let myDiv  = document.getElementById('the-div');
myDiv.addEventListener('mouseover',(event)=>{
   event.target.classList.remove('blue');
   event.target.classList.add('red');
});
myDiv.addEventListener('mouseout',(event)=>{
    event.target.classList.remove('red');
    event.target.classList.add('blue');
 });