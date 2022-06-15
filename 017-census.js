/**
 * В доме решили провести перепись всех жильцов и составили список,
 * в котором указали возраст и пол каждого жильца.
 *
 * Напишите функцию census(list) возвращающую номер в списке самого старшего жителя мужского пола.
 *
 * Пример:
 *
 * census([{ age: 12, gender: 'Male' }, { age: 40, gender: 'Male' }]) === 2
 * census([{ age: 40, gender: 'Female' }]) === undefined
 *
 * @param {object[]} list
 * @returns {undefined|number}
 */

function census(list) {
    let maxAge = 0;
    let index = undefined;
    for (let i = 0; i < list.length; i++) {
        if (list[i].age > maxAge && list[i].gender == 'Male') {
            maxAge = list[i].age;
            index = i + 1;
        }
    }
    return index;
}

alert(census([{ age: 12, gender: 'Male' }, { age: 40, gender: 'Male' }])) // 2
alert(census([{ age: 40, gender: 'Female' }])) // undefined
//module.exports = census;
