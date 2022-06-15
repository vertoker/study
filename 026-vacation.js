/**
 * Лена планирует свой двухнедельный отпуск.
 *
 * Напишите функцию vacation(date) вычисляющую день следующий за отпуском Лены
 *
 * Примечание: вместо ручного подсчета используй класс Date и его методы
 *
 * Пример:
 *
 * vacation('01.01.2020') === '15.01.2020'
 * vacation('27.01.2020') === '12.02.2020'
 *
 * @param {string} date
 * @returns {string}
 */
function vacation(date) {
    [day, month, year] = date.split('.');
    let now = new Date();
    now.setFullYear(year);
    now.setMonth(month);
    now.setDate(day);
    now.setDate(now.getDate() + 14);
    return now.getDate() + '.' + now.getMonth() + '.' + now.getFullYear();
}

alert(vacation('01.01.2020')) // '15.01.2020'
alert(vacation('27.01.2020')) // '12.02.2020'
module.exports = vacation;
