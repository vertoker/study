from math import *

# Задание 1
a = float(input('Введите a: '))
b = float(input('Введите b: '))
c = float(input('Введите c: '))
k = 1
while k <= 15:
    d = c + k
    p = (a + b + d) / 2
    s = sqrt(p * (p - a) * (p - b) * (p - d))
    print('При k =', k, 'получается площадь =', s)
    k = k + 1
print()
# Задание 2
n = 3
s = 0
k = 1
while k <= n:
    s = s + k
    k = k + 1
print(s)
print()
# Задание 3
n = int(input('Введите n: '))
p = 1
i = 1
while i <= n:
    p = p * 2
    i = i + 1
print(p)
print()
# Задание 4
n = int(input('Введите n: '))
s = 0
i = 1
while i <= n:
    s = s + sqrt(2)
    i = i + 1
print(s)
print()
# Задание 5
m = int(input('Введите m: '))
n = int(input('Введите n: '))
s = m
i = 1
while i <= n:
    s = s * (m + i)
    i = i + 1
print(s)
print()
# Задание 6
x = -3
y = 0
h = 0.5
while x <= 3:
    if abs(x) >= 1:
        y = pow(x, 2) + 1
    else:
        y = x
    print('При x =', x, 'получается y =', y)
    x = x + h
print()
# Задание 7
x = int(input('Введите делимое: '))
y = int(input('Введите делитель: '))
q = 0
r = x
while y < r:
    q = q + 1
    r = r - y
print('Частное равно', q)
print('Остаток равен', r)
print()
# Задание 8
# Взял отсюда
# https://foxford.ru/wiki/informatika/proverka-chisla-na-prostotu-v-python
a = int(input("Введите число: "))
d = 2
while a % d != 0:
    d += 1
if d == a:
    print(1)
else:
    print(0)
