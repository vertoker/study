/**
 * Напишите функцию rle(value) реализующую алгоритм сжатия строки.
 *
 * Пример:
 *
 * rle('AAABC') === '3ABC'
 * rle('AAAaaB') === '3A2aB'
 *
 * @param {string} value
 * @returns {string}
 */
function rle(value) {
    let result = '';
    for (let i = 0; i < value.length;) {
        let counter = 1;
        for (let j = i + 1; j < value.length; j++) {
            if (value[i] == value[j]) {
                counter++;
            }
            else {
                break;
            }
        }

        if (counter > 1) {
            result += counter;
        }
        result += value[i];
        i += counter;
    }
    return result;
}
alert(rle('AAABC')) // '3ABC'
alert(rle('AAAaaB')) // '3A2aB'
//module.exports = rle;
