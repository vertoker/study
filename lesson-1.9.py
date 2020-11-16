from random import *

def int_input(param):
    comment = 'Введите ' + param + ': '
    input_num = input(comment)
    try:
        return int(input_num)
    except ValueError:
        print('Введено не число')
        return int_input(param)

length = int_input('количество элементов списка')
countminus = 0
multiplyplus = 1
countplus = 0
l = []
for i in range(length):
    l.append(randint(-1000, 1000))
    if l[i] < 0:
        countminus = countminus + 1
    elif l[i] > 0:
        multiplyplus = multiplyplus * l[i]
        countplus = countplus + 1

print('Рандомный список чисел:', l)
print('Количество отрицательных:', countminus)
print('Произведение всех положительных:', multiplyplus)
shuffle(l)
print('Перемешанный список чисел:', l)

if countplus < 2:
    print('Количество положительных элементов меньше 2')
else:
    for i in range(length):
        if l[i] > 0:
            countplus = countplus - 1
            if countplus == 1:
                print('Индекс предпоследнего положительного числа списка равен', i)
                break
