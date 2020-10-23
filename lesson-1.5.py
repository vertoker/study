from math import *

# Задание 1
x = sqrt(1 + sqrt(1 + sqrt(1 + sqrt(1))))
y = (1 + sqrt(5)) / 2
print(x)
print(y)
print(x < y)
print()

x = pow(pi, e)
y = pow(e, pi)
print(x)
print(y)
print(x < y)
print()

x = log(6, 5)
y = log(7, 6)
print(x)
print(y)
print(x > y)
print()

x = pow(tan(radians(10)), 6) + pow(tan(radians(50)), 6) + pow(tan(radians(70)), 6)
y = 433
print(x)
print(y)
print(x == y)
print()

x = 16 * cos(2 * pi / 17)
y17 = sqrt(17)
y = sqrt(34 - 2 * y17) + y17 - 1 + 2 * sqrt(17 + 3 * y17 - sqrt(170 + 38 * y17))
print(x)
print(y)
print(x == y)
print()

# Задание 2
# 6
x = int(input('Введите x: '))
y = int(input('Введите y: '))
print('Расстояние равно', sqrt(x * x + y * y))
print()

# 8
p = int(input('Введите длину отрезка p в метрах: '))
print('В метрах длина равна', p)
print('В верстах длина равна', p / 1067)
print('В саженях длина равна', p / 1.829)
print('В аршинах длина равна', p * 0.7112)
print('В вершках длина равна', p * 22.4972)
