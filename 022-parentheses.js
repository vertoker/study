/**
 * Строка со скобками считается валидной, если на каждую закрывающую скобку имеется ранее открытая
 * и на каждую ранее открытую имеется закрывающая.
 *
 * Напишите функцию parentheses(value) проверяющую строку со скобками на валидность.
 *
 * Пример:
 *
 * parentheses('') === false
 * parentheses('()()') === true
 * parentheses('(()())') === true
 * parentheses('(()') === false
 * parentheses(')') === false
 *
 * @param {string} value
 * @returns {boolean}
 */
function parentheses(value) {
    if (value.length == 0) {
        return false;
    }

    let counter = 0;
    for (let i = 0; i < value.length; i++) {
        if (value[i] == '(') {
            counter++;
        }
        else if (value[i] == ')') {
            counter--;
        }
    }
    return counter == 0;
}

alert(parentheses('')) // false
alert(parentheses('()()')) // true
alert(parentheses('(()())')) // true
alert(parentheses('(()')) // false
alert(parentheses(')')) // false
module.exports = parentheses;
