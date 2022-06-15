/**
 * Одной банки с краской хватает на покраску 16 квадратных метров стен офиса.
 *
 * Напишите функцию repair(width, length, height) вычисляющую минимальное количество банок краски,
 * необходимых для покраски стен в офисе. Размерами дверей и окон можно пренебречь.
 *
 * Пример:
 *
 * repair(1, 1, 3) === 1
 * repair(4, 4, 3) === 3
 * repair(4, 4, 4) === 4
 *
 * @param {number} width – ширина офиса
 * @param {number} length - длина офиса
 * @param {number} height - высота стен в офисе
 * @returns {number}
 */
function repair(width, length, height) {
    let sideLR = height * length;
    let sideFB = height * width;
    let sideUD = length * width;

    let all = (sideLR + sideFB + sideUD) / 8;
    if (all - Math.floor(all) > 0) {
        all++;
    }
    return Math.floor(all);
}
alert(repair(1, 1, 3)) // 1
alert(repair(4, 4, 3)) // 5
alert(repair(4, 4, 4)) // 6
//module.exports = repair;

/*
width = 4
length = 4
height = 3
sideLR = 3 * 4 = 12
sideFB = 3 * 4 = 12
sideUD = 4 * 4 = 16
all = (12 + 12 + 16) * 2 = 40 * 2 = 80
allbottle = 80 / 16 = 5
Изначальный алгоритм некорректный
*/