from math import *
# Задание 1 - Разветвляющиеся алгоритмы
# Задание 1
a = int(input('Напишите первое вещественное число: '))
b = int(input('Напишите второе вещественное число: '))
if a > b:
    print('Первое число больше второго')
elif a < b:
    print('Второе число больше первого')
else:
    print('Первое число и второе равны')
print()

# Задание 2
n = int(input('Напишите число: '))
a = int(input('Напишите делитель: '))
if n % a == 0:
    print('Делитель является целочисленным делителем')
else:
    print('Делитель не является целочисленным делителем')
print()

# Задание 3
x = float(input('Напишите x координату точки: '))
if x > 4:
    print('Точка находится во второй области')
elif x < 4:
    print('Точка находится во первой области')
else:
    print('Точка находится на границе областей')
print()

# Задание 4
x = float(input('Напишите входное число x: '))
if x > 0:
    print('y =', pow(sin(x), 2))
else:
    print('y =', 1 - sin(pow(x, 2)))
print()

# Задание 5
r = float(input('Напишите радиус круга: '))
a = float(input('Напишите сторону квадрата: '))
Sr = pi * r * r
Sa = a * a
if Sr > Sa:
    print('Площадь круга больше площади квадрата')
elif Sa > Sr:
    print('Площадь квадрата больше площади круга')
else:
    print('Квадрат и круг равны по площади')
print()

# Задание 6
n = int(input('Напишите число: '))
if n % 2 == 1:
    print('Следующее чётное число равно', n + 1)
else:
    print('Число является чётным')
print()

# Задание 7
a = float(input('Напишите первый коэффициент квадратного уравнения: '))
b = float(input('Напишите второй коэффициент квадратного уравнения: '))
c = float(input('Напишите третий коэффициент квадратного уравнения: '))
D = pow(b, 2) - 4 * a * c
if D > 0:
    x1 = (-b + sqrt(D)) / (2 * a)
    x2 = (-b - sqrt(D)) / (2 * a)
    print('Первый корень равен', x1)
    print('Второй корень равен', x2)
elif D == 0:
    x = -b / 2 * a
    print('Корень равен', x)
else:
    print('Квадратное уравнение не существует')
print()

# Задание 2 - Структура выбора
# Задание 1
a = float(input('Напишите первое число: '))
b = float(input('Напишите второе число: '))
operation = input('Какую операцию стоит провести с числами: ')
if operation == '+':
    print('Сумма введёных чисел равна', a + b)
elif operation == '-':
    print('Разность введёных чисел равна', a - b)
elif operation == '*':
    print('Произведение введёных чисел равна', a * b)
elif operation == '/':
    if b == 0:
        print('Нельзя делить на 0')
    else:
        print('Частное введёных чисел равна', a / b)
else:
    print('Неизвестная операция')
print()

# Задание 2
day = int(input('Напишите день: '))
month = int(input('Напишите месяц: '))
year = int(input('Напишите год: '))
print('Текущий день - ', day, '.', month, '.', year, sep = '')
if month == 2:
    if day < 28:
        day += 1
    else:
        month += 1
        day = 1
elif month == 4 or month == 6 or month == 9 or month == 11:
    if day < 30:
        day += 1
    else:
        month += 1
        day = 1
else:
    if day < 31:
        day += 1
    else:   
        if month == 12:
            year += 1
            month = 1
            day = 1
        else:
            month += 1
            day = 1
print('Следующий день - ', day, '.', month, '.', year, sep = '')
print()
