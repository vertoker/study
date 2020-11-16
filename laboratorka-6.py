def int_input(param):
    comment = 'Введите ' + param + ': '
    input_num = input(comment)
    try:
        return int(input_num)
    except ValueError:
        print('Введено не число')
        return int_input(param)

# Вариант 23
# Задание 1
R1 = int_input('R1')
R2 = int_input('R2')
R3 = int_input('R3')
R = (R1 * R2 * R3) / (R1 * R2 + R2 * R3 + R1 * R3)
print('Сопротивление соединения', R)
print()

# Вариант 5 => 23 - 18 = 5
# Задание 2
n1 = int_input('первое число')
n2 = int_input('второе число')
n3 = int_input('третье число')
summa = min(n1, n2, n3) + max(n1, n2, n3)
print('Сумма наибольшего и наименьшего числа равна', summa)
