/**
 * С числами Фибоначчи мы уже познакомились в прошлой задаче.
 *
 * Напишите функцию isFibonacci(value) которая определяет, является ли value числом Фибоначчи.
 *
 * Пример:
 *
 * isFibonacci(1) === 1
 * isFibonacci(2) === 3
 * isFibonacci(55) === 10
 * isFibonacci(52) === undefined
 *
 * @param {number} value
 * @returns {undefined|number}
 */
function isFibonacci(value) {
    if (value < 1)
        return undefined;
    if (value == 1)
        return 1;
    
    lastResult = 0;
    result = 1;
    iteration = 1;
    while (result < value) {
        let next = lastResult + result;
        lastResult = result;
        result = next;
        iteration++;
    }
    if (result == value){
        return iteration;
    }
    return undefined;
}

//module.exports = isFibonacci;

alert(isFibonacci(1));
alert(isFibonacci(2));
alert(isFibonacci(55));
alert(isFibonacci(52));