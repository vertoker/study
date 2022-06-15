/**
 * Hex и RGB - текстовые форматы для представления цвета в коде.
 *
 * Напишите функцию hexToRgb(color) конвертирующую цвет закодированный в формате HEX
 * в RGB кодированную строку.
 *
 * Пример:
 *
 * hexToRgb('#000000') === 'rgb(0, 0, 0)'
 * hexToRgb('#fff') === 'rgb(255, 255, 255)'
 * hexToRgb('#800080') === 'rgb(128, 0, 128)'
 *
 * @param {string} color
 * @returns {string}
 */

function convert(hexNum){
    return parseInt(hexNum, 16);
}

function hexToRgb(color) {
    if (color[0] == '#') {
        return hexToRgb(color.substring(1));
    }
    if (color.length == 3) {
        return hexToRgb(color[0] + color[0] + color[1] + color[1] + color[2] + color[2]);
    }
    if (color.length != 6) {
        return undefined;
    }

    let r = convert(color[0] + color[1]);
    let g = convert(color[2] + color[3]);
    let b = convert(color[4] + color[5]);
    return [r, g, b];
}
alert(hexToRgb('#000000')) // 'rgb(0, 0, 0)'
alert(hexToRgb('#fff')) // 'rgb(255, 255, 255)'
alert(hexToRgb('#800080')) // 'rgb(128, 0, 128)'
module.exports = hexToRgb;
