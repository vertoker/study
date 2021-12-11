/**
 * Напишите функцию getTimeDelta(x, y) определяющую,
 * сколько секунд прошло между двумя моментами времени x и y.
 *
 * Время передается в формате 'HH:MM:SS'. Минимальное значение – '00:00:00', максимальное – '23:59:59'.
 *
 * По условию x всегда меньше y.
 *
 * Пример:
 *
 * getTimeDelta('00:00:00', '00:00:01') === 1
 * getTimeDelta('01:01:01', '02:02:02') === 3661
 * getTimeDelta('01:19:30', '01:20:20') === 50
 *
 * @param {string} time
 * @returns {number}
 */
function convertTimeToSeconds(time) {
    var nums = time.split(':');
    let hours = parseInt(nums[0]) * 3600;
    let minutes = parseInt(nums[1]) * 60;
    let seconds = parseInt(nums[2]);
    return hours + minutes + seconds;
}

/**
* @param {string} x
* @param {string} y
* @returns {number} разница между x и y в секундах
*/
function getTimeDelta(x, y) {
    let time1 = new Date(x).getTime();
    let time2 = new Date(y).getTime();
    return time2 - time1;
}

console.log(getTimeDelta('00:00:00', '00:00:01'));
console.log(getTimeDelta('01:01:01', '02:02:02'));
console.log(getTimeDelta('01:19:30', '01:20:20'));
