/**
 * Слова-анаграммы — это слова, записанные одними и теми же буквами в разном порядке,
 * регистр букв при этом игнорируется.
 * Анаграммами, например, являются слова «Волос» и «СЛОВО».
 *
 * Напишите функцию anagram(x, y) проверяющую, являются ли x и y словами-анаграммами.
 *
 * Пример:
 *
 * anagram('Волос', 'Слово') === true
 * anagram('Живу', 'Вижу') === true
 *
 * @param {string} x
 * @param {string} y
 * @returns {boolean}
 */
function anagram(x, y) {
    var lettersX = x.toLowerCase().split('');
    var lettersY = y.toLowerCase().split('');

    if (lettersX.length != lettersY.length) {
        return false;
    }

    for (let i = 0; i < lettersX.length; i++) {
        var index = -1;

        for (let j = 0; j < lettersY.length; j++) {
            if (lettersX[i] == lettersY[j]) {
                index = j;
                break;
            }
        }
        
        if (index != -1){
            lettersY.slice(index, 1);
        }
        else{
            return false;
        }
    }
    return true;
}
alert(anagram('Волос', 'Слово')) // true
alert(anagram('Живу', 'Вижу')) // true
alert(anagram('Слово 1', 'Слово 2')) // false
//module.exports = anagram;
