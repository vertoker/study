// Import stylesheets
import './style.css';

const addButton = document.getElementById('todoAdd') as HTMLElement;
const input = document.getElementById('todoInput') as HTMLButtonElement;
const todoList = document.getElementById('todoList') as HTMLElement;

addButton.addEventListener('click', addTodo);

function addTodo(this: HTMLElement, ev: Event) {
  if (input.value.length == 0) {
    return;
  }
  let todoDiv = document.createElement('div');
  todoDiv.classList.add('todo');

  let newTodo = document.createElement('li');
  newTodo.innerText = input.value;
  newTodo.classList.add('todo-item');
  todoDiv.appendChild(newTodo);
  input.value = '';

  let trashBtn = document.createElement('button');
  trashBtn.innerHTML = '<i class="fas fa-trash"></i>';
  trashBtn.classList.add('trash-btn');
  trashBtn.addEventListener('click', deleteTodo);
  todoDiv.appendChild(trashBtn);

  todoList.appendChild(todoDiv);
}

function deleteTodo(this: HTMLElement, ev: Event) {
  const todo = this.parentElement;
  todo.classList.add('fall');
  todo.addEventListener('transitionend', (e) => {
    todo.remove();
  });
}
