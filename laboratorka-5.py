# Вариант 23 => 1 и 14
# Задание 1
num = int(input('Введите натуральное число: '))
while num > 0:
    print(num % 10)
    num //= 10
print()

# Задание 14
num = int(input('Введите натуральное число: '))
result = 0
while num > 0:
    if num % 10 < 5:
        result = result + 1
    num //= 10
print('Количество цифр меньших 5 =', result)
