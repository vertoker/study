/**
 * Самый простой способ зашифровать строку – сдвиг букв.
 * Под сдвигом понимается замена буквы на предыдущую в алфавите.
 * Если предыдущей буквы нет, она заменяется на последнюю букву алфавита (в этой задаче мы имеем дело с английским алфавитом).
 *
 * Вам прислали секретное сообщение, зашифрованное способом, описанным выше и состоящее из строчных английских букв.
 *
 * Напишите функцию decrypt(secret) которая расшифрует и вернет его.
 *
 * Пример:
 *
 * decrypt('bnqqdbs') === 'correct'
 * decrypt('zmc vd hfmnqd rozbdr') === 'and we ignore spaces'
 *
 * @param {string} secret
 * @returns {string}
 */

let alphabet = "abcdefghigklmnopqrstuvwxyz";
function decrypt(secret) {
    let result = "";
    for (let index = 0; index < secret.length; index++) {
        const letter = secret[index];
        let next = alphabet.indexOf(letter);
        if (next != -1) {
            next += 1;
            if (next >= alphabet.length){
                next -= alphabet.length;
            }
            result += alphabet[next];
        }
        else{
            result += letter;
        }
    }
    return result;
}

//module.exports = decrypt;

alert(decrypt('bnqqdbs'));
alert(decrypt('zmc vd hfmnqd rozbdr'));