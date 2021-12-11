/**
 * Известны результаты каждой из 4х четвертей баскетбольной встречи.
 * Нужно определить победителя матча. Побеждает команда,
 * набравшая больше очков в течение всего матча.
 *
 * Напишите функцию getWinner(points) возвращающую номер победившей команды,
 * либо undefined в случае ничьей.
 *
 * Пример:

 * getWinner(['23-26', '24-30', '30-27', '35-31']) === 2
 * getWinner(['36-32', '32-24', '20-28', '30-26']) === 1
 * getWinner(['36-18', '22-31', '27-21', '19-34']) === undefined
 *
 * @param {string[]} points
 * @returns {(number|undefined)}
 */
function getWinner(points) {
    let points1 = 0, points2 = 0;
    for (let i = 0; i < points.length; i++) {
        const arrayString = points[i].split("-");
        points1 += parseInt(arrayString[0]);
        points2 += parseInt(arrayString[1]);
    }
    return points1 > points2 ? 1 : (points1 < points2 ? 2 : undefined);
}

console.log(getWinner(['23-26', '24-30', '30-27', '35-31']));
console.log(getWinner(['36-32', '32-24', '20-28', '30-26']));
console.log(getWinner(['36-18', '22-31', '27-21', '19-34']));
