// Import stylesheets
import './style.css';

// Write TypeScript code!
const appDiv: HTMLElement = document.getElementById('app');
const input = document.getElementById('input') as HTMLButtonElement;
const butPlus = document.getElementById('but+') as HTMLElement;
const butMinus = document.getElementById('but-') as HTMLElement;
const butMultiply = document.getElementById('but*') as HTMLElement;
const butDivision = document.getElementById('but/') as HTMLElement;
butPlus.addEventListener('click', () => {
  Add('+');
});
butMinus.addEventListener('click', () => {
  Add('-');
});
butMultiply.addEventListener('click', () => {
  Add('*');
});
butDivision.addEventListener('click', () => {
  Add('/');
});

for (let i = 0; i < 10; i++) {
  const but = document.getElementById('but' + i) as HTMLElement;
  but.addEventListener('click', () => {
    Add(i);
  });
}

function Add(char) {
  input.value += char;
}
