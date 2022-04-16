/**
 * Напишите функцию sortTimestamps(list) сортирующую список временных моментов.
 *
 * Пример:
 *
 * sortTimestamps(['23:02:59', '02:07:00']) === ['02:07:00', '23:02:59']
 *
 * @param {string[]} list массив временных моментов представленных в виде строк в формате 'HH:MM:SS'
 * @returns {string[]} отсортированный по возрастанию массив временных моментов
 */
function sortTimestamps(list) {
    let timeArray = [];
    for (let index = 0; index < list.length; index++) {
        let [hours, minutes, seconds] = list[index].split(':');
        timeArray.add(parseInt(hours) * 3600 + parseInt(minutes) * 60 + parseInt(seconds));
    }
    timeArray.sort();
    list = [];
    for (let index = 0; index < timeArray.length; index++) {
        const element = array[index];
        let hours = 
    }
}

module.exports = sortTimestamps;
alert(sortTimestamps(['23:02:59', '02:07:05', '02:07:00']));