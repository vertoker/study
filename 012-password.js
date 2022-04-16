/**
 * Пароль называется криптостойким,
 * если он включает в себя хотя бы одну строчную английскую букву,
 * хотя бы одну заглавную английскую букву и хотя бы одну цифру,
 * при этом его длина должна быть не менее 7 символов.
 *
 * Напишите функцию validatePassword(password) определяющую,
 * является ли переданный пароль криптостойким.
 *
 * Пример:
 *
 * validatePassword('abc4DEFG') === true
 * validatePassword('abcdefg') === false
 * validatePassword('abcdefG') === false
 * validatePassword('abcdef7') === false
 *
 * @param {string} password
 * @returns {boolean}
 */
let alphabet = "abcdefghigklmnopqrstuvwxyz";
let ALPHABET = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
let numbers = "1234567890";
function validatePassword(password) {
    let hasLower = false, hasUpper = false, hasNumbers = false;
    for (let index = 0; index < password.length; index++) {
        const letter = password[index];
        if (alphabet.includes(letter)) {
            hasLower = true;
        }
        if (ALPHABET.includes(letter)) {
            hasUpper = true;
        }
        if (numbers.includes(letter)) {
            hasNumbers = true;
        }
    }
    return hasLower && hasUpper && hasNumbers;
}

//module.exports = validatePassword;
alert(validatePassword('abc4DEFG'));
alert(validatePassword('abcdefg'));
alert(validatePassword('abcdefG'));
alert(validatePassword('abcdef7'));