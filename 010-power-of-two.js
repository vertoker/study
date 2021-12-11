/**
 * Напишите функцию getPower(n) возвращающую целочисленное значение степени >= 0,
 * в которую нужно возвести двойку, чтобы получить n
 *
 * Пример:
 *
 * getPower(2) === 1            # 2^1 = 2
 * getPower(3) === undefined
 * getPower(256) === 8          # 2^8 = 256
 *
 * @param {number} n
 * @returns {number|undefined}
 */
function getPower(n) {
    let power = 0;
    let num = 1;
    while (true) {
        if (n == num) {
            return power;
        }
        else if (n < num) {
            return undefined;
        }
        
        num *= 2;
        power += 1;
    }
}

console.log(getPower(2));
console.log(getPower(3));
console.log(getPower(256));