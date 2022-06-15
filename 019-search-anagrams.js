/**
 * Со словами-анаграммами мы познакомились в прошлой задаче.
 *
 * Напишите функцию searchAnagrams(value) возвращающую слова-анаграммы из предложения,
 * сохраняя их порядок и регистр букв
 *
 * Пример:
 *
 * searchAnagrams('Вижу апельсин значит живу. Спаниель') === 'Вижу апельсин живу Спаниель'
 *
 * @param {string} value
 * @returns {string}
 */

 let specialSymbols = ".,:;-=+?!_@#$%^&|*()";

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

function searchAnagrams(value) {
    for (let i = 0; i < specialSymbols.length; i++) {
        value = value.split(specialSymbols[i]).join('');
    }
    value = value.replace(/ +(?= )/g,'');
    let words = value.split(' ');
    let anagrams = new Array(words.length).fill(false);

    for (let i = 0; i < words.length; i++) {
        for (let j = i + 1; j < words.length; j++) {
            if (anagram(words[i], words[j])) {
                anagrams[i] = true;
                anagrams[j] = true;
            }
        }
    }

    let result = '';
    for (let i = 0; i < words.length; i++) {
        if (anagrams[i] == true) {
            if (result.length != 0) {
                result += ' ';
            }
            result += words[i];
        }
    }
    return result;
}

alert(searchAnagrams('Вижу апельсин значит живу: - Спаниель')); // 'Вижу апельсин живу Спаниель'
alert(searchAnagrams('Вижу - живу. Вижу - живу. Вижу - живу')); // 'Вижу живу Вижу живу Вижу живу'
alert(searchAnagrams('Old Godzilla was hoping around, tokyo city like a big playground')); // ''

//module.exports = searchAnagrams;
