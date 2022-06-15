/**
 * Петя опубликовал картинку X секунд назад.
 *
 * Напишите функцию timeago(seconds) возвращаю текстовое представление периода прошедшего со времени публикации.
 * Для публикаций опубликованных более четырёх недель назад возвращайте строку 'undefined', ведь их никто не увидит.
 *
 * Пример:
 *
 * timeago(0) === 'just now'
 * timeago(10) === '10 seconds ago'
 * timeago(60) === '1 minute ago'
 * timeago(3600) === '1 hour ago'
 *
 * @param {number} seconds
 * @returns {string}
 */
function timeago(seconds) {
    if (seconds == 0) {
        return 'just now';
    }
    else if (seconds < 60){
        return seconds + ' seconds ago';
    }
    else if (seconds < 3600){
        seconds = Math.floor(seconds / 60);
        if (seconds == 1) {
            return seconds + ' minute ago';
        }
        return seconds + ' minutes ago';
    }
    else if (seconds < 84600){
        seconds = Math.floor(seconds / 3600);
        if (seconds == 1) {
            return seconds + ' hour ago';
        }
        return seconds + ' hours ago';
    }
    else if (seconds < 604800){
        seconds = Math.floor(seconds / 84600);
        if (seconds == 1) {
            return seconds + ' day ago';
        }
        return seconds + ' days ago';
    }
    else if (seconds <= 2419200){
        seconds = Math.floor(seconds / 604800);
        if (seconds == 1) {
            return seconds + ' week ago';
        }
        return seconds + ' weeks ago';
    }
    return undefined;
}
alert(timeago(0)) // 'just now'
alert(timeago(10)) // '10 seconds ago'
alert(timeago(60)) // '1 minute ago'
alert(timeago(3600)) // '1 hour ago'
module.exports = timeago;
