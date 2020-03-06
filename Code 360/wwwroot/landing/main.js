const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');
//declearing the variables using their id names

//when signup is clicked it adds this class
signUpButton.addEventListener('click', () => {
	container.classList.add("right-panel-active");
});

//when sign in is clicked it removes the class
signInButton.addEventListener('click', () => {
	container.classList.remove("right-panel-active");
});