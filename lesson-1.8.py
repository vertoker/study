from random import *

# Задание 1
p = 0
print('Сгенерированные стороны: ', end = '')
for i in range(12):
    side = randint(1, 10)
    print(side, end = ' ')
    p = p + side
print('\n', 'Периметр =', p, end = '\n\n')

# Задание 2
s = 0
print('Сгенерированные целые числа: ', end = '')
for i in range(10):
    num = randint(0, 9999)
    print(num, end = ' ')
    if num % 10 == 0:
        s = s + 1
print('\n', 'Сумма чисел, оканчивающихся 0 =', s, end = '\n\n')

# Задание 3
s = 0
print('Сгенерированные осадки за каждый день месяца: ', end = '')
for i in range(1, 31):
    num = randint(0, 10)
    print(num, end = ' ')
    if i % 2 == 0:
        s = s + num
print('\n', 'Общее количество осадков за чётные дни (в мм) =', s, end = '\n\n')


# Задание 4
s = 0
print('Сгенерированные росты юношей: ', end = '')
for i in range(10):
    num = randint(140, 190)
    print(num, end = ' ')
    if num < 165:
        s = s + 1
print('\n', 'Количество юношей с ростом меньше 165 см =', s, end = '\n\n')


# Задание 5
s = 0
print('Сгенерированные оценки у учеников: ', end = '')
for i in range(25):
    num = randint(2, 5)
    print(num, end = ' ')
    if num == 5:
        s = s + 1
print('\n', 'Количество учеников с пятёрками =', s, end = '\n\n')
