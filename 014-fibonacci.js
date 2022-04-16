/**
 * Последовательностью Фибоначчи называется последовательность чисел
 * a0, a1, ..., an, ..., где
 * a0 = 0,
 * a1 = 1,
 * ak = ak-1 + ak-2 (k > 1).
 *
 * Напишите функцию fibonacci(n) вычисляющую n-ное число последовательности
 *
 * Пример:
 *
 * fibonacci(2) === 1
 * fibonacci(3) === 2
 * fibonacci(7) === 13
 *
 * @param {number} n >= 0
 * @returns {number}
 */
function fibonacci(n) {
    if (n < 2)
        return 0;
    lastResult = 1;
    result = 0;
    for (let index = 0; index < n; index++) {
        let next = lastResult + result;
        lastResult = result;
        result = next;
    }
    return result;
}

//module.exports = fibonacci;
alert(fibonacci(1));
alert(fibonacci(2));
alert(fibonacci(3));
alert(fibonacci(7));