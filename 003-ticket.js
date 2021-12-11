/**
 * Счастливым билетом называют такой билет с шестизначным номером,
 * где сумма первых трех цифр равна сумме последних трех.
 *
 * Напишите функцию checkTicket(number) которая проверяет счастливость билета.
 *
 * Пример:
 *
 * checkTicket('005212') === true
 * checkTicket('133700') === true
 * checkTicket('123032') === false
 *
 * @param {string} number
 * @returns {boolean}
 */
function checkTicket(number) {
    let leftPart = parseInt(number[0]) + parseInt(number[1]) + parseInt(number[2]);
    let rightPart = parseInt(number[3]) + parseInt(number[4]) + parseInt(number[5]);
    return leftPart == rightPart;
}

console.log(checkTicket('005212'));
console.log(checkTicket('133700'));
console.log(checkTicket('123032'));
