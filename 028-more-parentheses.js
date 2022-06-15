/**
 * Ранее мы уже решали задачу валидации последовательности скобок в строке.
 *
 * На этот раз напишите функцию parentheses(value) валидирующую строку с несколькими типами скобок.
 *
 * Пример:
 *
 * parentheses('<>') === true
 * parentheses('<}') === false
 *
 * @param {string} value – строка из набора символов (, ), {, }, <, >.
 * @returns {boolean}
 */
function parenthesesCurrent(value, symbolOpen, symbolClose) {
    let counter = 0;
    for (let i = 0; i < value.length; i++) {
        if (value[i] == symbolOpen) {
            counter++;
        }
        else if (value[i] == symbolClose) {
            counter--;
        }
    }
    return counter == 0;
}
function parentheses(value) {
    if (value.length == 0)
        return false;
    let standard = parenthesesCurrent(value, '(', ')');
    let squared = parenthesesCurrent(value, '[', ']');
    let figured = parenthesesCurrent(value, '{', '}');
    let angled = parenthesesCurrent(value, '<', '>');
    return standard && squared && figured && angled;
}
alert(parentheses('<>')) // true
alert(parentheses('<}')) // false
alert(parentheses('<()[]{}<>>')) // true

module.exports = parentheses;
