/**
 * Витя из дома до работы добирается по кольцевой линии метро.
 *
 * Напишите функцию metro(x,y) вычисляющую минимальное количество промежуточных станций
 * (не считая станции посадки и высадки), которые необходимо проехать Вите,
 * если на кольцевой линии 13 станций.
 *
 * Пример:
 *
 * metro(1, 2) === 0
 * metro(1, 3) === 1
 * metro(13, 1) === 0
 * metro(1, 13) === 0
 *
 * @param {number} x – станция посадки
 * @param {number} y - станция высадки
 * @returns {number}
 */
function metro(x, y) {
    if (x > y)
        return Math.min(y + 13 - x, x - y) - 1;
    return Math.min(x + 13 - y, y - x) - 1;
}

alert(metro(1, 2)) // 0
alert(metro(1, 3)) // 1
alert(metro(13, 1)) // 0
alert(metro(1, 13)) // 0
module.exports = metro;
