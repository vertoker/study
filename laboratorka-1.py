from math import *
# Вариант 8
# Задание 1
a = radians(float(input('Введите значение a в градусах: ')))
b = radians(float(input('Введите значение b в градусах: ')))
y = pow(cos(a) - cos(b), 2) - pow(sin(a) - sin(b), 2)
z = -4 * pow(sin((a - b) / 2), 2) * cos(a + b)
print('y равен', '%.3f'% y)
print('z равен', '%.3f'% z)
print()

# Задание 2
num = int(input('Введите номер квартиры: ')) - 1
entrace = num // 36 + 1
floor = num % 36 // 4 + 1
quart = num % 36 % 4 + 1
print('Подьезд квартиры -', entrace)
print('Этаж квартиры -', floor)
print('Номер квартиры на этаже -', quart)
