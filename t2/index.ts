// Import stylesheets
import './style.css';

// Write TypeScript code!
const appDiv: HTMLElement = document.getElementById('app');

const input = document.getElementById('input') as HTMLButtonElement;
const but1 = document.getElementById('but1') as HTMLElement;
const but2 = document.getElementById('but2') as HTMLElement;

but1.addEventListener('click', Lock);
but2.addEventListener('click', Unlock);

function Lock() {
  input.disabled = true;
}
function Unlock() {
  input.disabled = false;
}
