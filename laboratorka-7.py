from random import *

# Вариант 23
l = []
a = []
for i in range(100):
    l.append(randint(-1000, 1000))
    if l[i] % 5 == 0:
        a.append(l[i])
print('Оригинальный массив:', l)
print('Массив с числами, кратные 5:', a)
