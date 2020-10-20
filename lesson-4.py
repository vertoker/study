# 1
name = input('Введите своё имя: ')
print('Привет, ', name, '!', sep = '')
print()

# 2
num = int(input('Введите целое число: '))
print('Следующее за числом', num, 'число -', num + 1)
print('Для числа', num, 'предыдущее число -', num - 1)
print()

# 3
num1 = int(input('Введите первое число: '))
num2 = int(input('Введите второе число: '))
print(num1, '+', num2, '=', num1 + num2)
print(num1, '-', num2, '=', num1 - num2)
print(num1, '*', num2, '=', num1 * num2)
print(num1, '/', num2, '=', num1 / num2)
print()

# 4
n = int(input('Введите количество школьников: '))
k = int(input('Введите количество яблок: '))
print('Каждому школьнику достанется', k // n, 'яблок')
print('В корзине останется', k % n, 'яблок')
print()

# 5
num = int(input('Введите двухзначное число: '))
num1 = num % 10
num = num // 10
num2 = num % 10
print('Сумма цифр числа равна', num1 + num2)
print()

# 6
num = int(input('Введите трёхзначное число: '))

digit = num % 10
num3 = digid
num = num // 10
digit = num % 10
num2 = digit
num = num // 10
digit = num % 10
num1 = digit
num = num // 10

print(num1, ', ', num2, ', ', num3, sep = '')
print()

# 7
num1 = int(input('Введите четырёхзначное число: '))
num2 = int(input('Введите пятизначное число: '))

suma = 0
while num1 > 0:
    digit = num1 % 10
    suma = suma + digit
    num1 = num1 // 10

mult = 1
while num2 > 0:
    digit = num2 % 10
    mult = mult * digit
    num2 = num2 // 10

print('Сумма четырёхзначного числа равна', suma)
print('Произведение пятизначного числа равно', mult)
print()
