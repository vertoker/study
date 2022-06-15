/**
 * Напишите функцию has(path, object) возвращающую true, если в объекте есть свойство
 * описанное массивом path, иначе false
 *
 * Пример:
 *
 * has(['a'], { a: 1 }) === true
 * has(['b'], { a: 1 }) === false
 * has(['o', 'a'], { o: { a: 2 } }) === true
 *
 * @param {string[]} path
 * @param {object} object
 * @returns {boolean}
 */
function listAllProperties(o){
	var objectToInspect;
	var result = [];

	for(objectToInspect = o; objectToInspect !== null; objectToInspect = Object.getPrototypeOf(objectToInspect)){
		result = result.concat(Object.getOwnPropertyNames(objectToInspect));
	}

	return result;
}
function has(path, object) {
    for (let i in path) {
        if (object.hasOwnProperty(path[i])) {
            return true;
        }
    }
    return false;
}
alert(has(['a'], { a: 1 })) // true
alert(has(['b'], { a: 1 })) // false
alert(has(['o', 'a'], { o: { a: 2 } })) // true
module.exports = has;
