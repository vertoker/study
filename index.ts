import './style.css';

enum Field {
  N = '',
  X = 'X',
  O = 'O',
}

class Playground3x3 {
  turn: Field;
  fields: Field[];
  counter: number;

  constructor(firstMove: Field) {
    this.counter = 0;
    this.turn = firstMove;
    this.fields = [];
    for (let i = 0; i < 9; i++) {
      this.fields[i] = Field.N;
    }
  }

  reverse(): void {
    if (this.turn == Field.O) {
      this.turn = Field.X;
    } else if (this.turn == Field.X) {
      this.turn = Field.O;
    }
  }

  move(n: number): boolean {
    if (this.fields[n] == Field.N) {
      this.counter++;
      this.fields[n] = this.turn;
      return true;
    }
    return false;
  }

  isFinish(): boolean {
    return condition(this);
  }
  isEnded(): boolean {
    return this.counter == 9;
  }
}

function condition(playground: Playground3x3) {
  let c1 = playground.fields[0] == playground.turn;
  let c2 = playground.fields[1] == playground.turn;
  let c3 = playground.fields[2] == playground.turn;
  let c4 = playground.fields[3] == playground.turn;
  let c5 = playground.fields[4] == playground.turn;
  let c6 = playground.fields[5] == playground.turn;
  let c7 = playground.fields[6] == playground.turn;
  let c8 = playground.fields[7] == playground.turn;
  let c9 = playground.fields[8] == playground.turn;

  let s1 = c1 && c2 && c3;
  let s2 = c4 && c5 && c6;
  let s3 = c7 && c8 && c9;
  let s4 = c1 && c4 && c7;
  let s5 = c2 && c5 && c8;
  let s6 = c3 && c6 && c9;
  let s7 = c1 && c5 && c9;
  let s8 = c3 && c5 && c7;

  return s1 || s2 || s3 || s4 || s5 || s6 || s7 || s8;
}

///////////////////////////////////////////////////////////////////////////////////////////////////////

let cells = [];
for (let i = 0; i < 9; i++) {
  cells[i] = document.getElementById(String(i)) as HTMLElement;
  cells[i].addEventListener('click', () => {
    click(i);
  });
}

let status = document.getElementById(String('game-status')) as HTMLElement;
let selecter = document.getElementById(String('game-selecter')) as HTMLElement;
let selectO = document.getElementById(String('selectO')) as HTMLElement;
let selectX = document.getElementById(String('selectX')) as HTMLElement;
selectO.addEventListener('click', selectSideO);
selectX.addEventListener('click', selectSideX);

let gameContainer = document.getElementById('game-container') as HTMLElement;
let restartBtn = document.getElementById('game-restart') as HTMLElement;
restartBtn.addEventListener('click', restart);

let playground = new Playground3x3(Field.N);
function selectSideO() {
  startGame(Field.O);
}
function selectSideX() {
  startGame(Field.X);
}
function click(n: number) {
  if (playground.turn != Field.N) {
    pressField(n);
  }
}

function pressField(numberField: number) {
  let isMove = playground.move(numberField);
  if (playground.isFinish()) {
    status.innerHTML = 'Победитель: ' + playground.turn;
    playground.turn = Field.N;
  } else if (playground.isEnded()) {
    status.innerHTML = 'Ничья';
    playground.turn = Field.N;
  } else if (isMove) {
    playground.reverse();
    status.innerHTML = 'Сейчас ходит ' + playground.turn;
  }
  cells[numberField].innerHTML = playground.fields[numberField];
}
function startGame(side: Field) {
  selecter.classList.add('invisible');
  playground = new Playground3x3(side);
  status.innerHTML = 'Сейчас ходит ' + playground.turn;
}

function restart() {
  status.innerHTML = 'Чей первый ход?';
  selecter.classList.remove('invisible');
  playground.turn = Field.N;
  for (let i = 0; i < 9; i++) {
    cells[i].innerHTML = '';
  }
}

restart();
