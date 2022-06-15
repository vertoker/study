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
 function Repeat(value, length)
 {
     return value - Math.floor(value / length) * length;
 }
function sortTimestamps(list) {
    let timeArray = [];
    for (let index = 0; index < list.length; index++) {
        let [hours, minutes, seconds] = list[index].split(':');
        timeArray.push(parseInt(hours) * 3600 + parseInt(minutes) * 60 + parseInt(seconds));
    }
    timeArray.sort();
    list = [];
    for (let index = 0; index < timeArray.length; index++) {
        let time = timeArray[index];
        let hours = Math.floor(time / 3600);
        let minutes = Math.floor((time - hours * 3600) / 60);
        let seconds = time - hours * 3600 - minutes * 60;

        if (hours < 10) {
            hours = '0' + hours;
        }
        if (minutes < 10) {
            minutes = '0' + minutes;
        }
        if (seconds < 10) {
            seconds = '0' + seconds;
        }

        list.push(hours + ':' + minutes + ':' + seconds);
    }
    return list;
}

//module.exports = sortTimestamps;
alert(sortTimestamps(['23:02:59', '02:07:05', '02:07:00']));