// Import stylesheets
import './style.css';

// Write TypeScript code!
const appDiv: HTMLElement = document.getElementById('app');
const input = document.getElementById('input') as HTMLButtonElement;
const but = document.getElementById('but') as HTMLElement;
const result = document.getElementById('result') as HTMLElement;

but.addEventListener('click', Pow2);

function Pow2() {
  result.innerHTML = Number(input.value) * Number(input.value);
}
