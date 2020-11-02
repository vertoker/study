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
plus = num1 + num2
minus = num1 - num2
multiply = num1 * num2
divide = num1 / num2
between = (num1 + num2) / 2
print(num1, '+', num2, '=', plus, end = ' ')
print(num1, '-', num2, '=', minus, end = ' ')
print(num1, '*', num2, '=', multiply, end = ' ')
print(num1, '/', num2, '=', divide)
print('(', num1, ' + ', num2, ') / 2 = ', between, sep = '')
print()

# 4
n = int(input('Введите количество школьников: '))
k = int(input('Введите количество яблок: '))
f = k // n
uf = k % n
print('Каждому школьнику достанется', f, 'яблок')
print('В корзине останется', uf, 'яблок')
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
num3 = digit
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
digit = num1 % 10
suma = suma + digit
num1 = num1 // 10

digit = num1 % 10
suma = suma + digit
num1 = num1 // 10

digit = num1 % 10
suma = suma + digit
num1 = num1 // 10

digit = num1 % 10
suma = suma + digit
num1 = num1 // 10

mult = 1
digit = num2 % 10
mult = mult * digit
num2 = num2 // 10

digit = num2 % 10
mult = mult * digit
num2 = num2 // 10

digit = num2 % 10
mult = mult * digit
num2 = num2 // 10

digit = num2 % 10
mult = mult * digit
num2 = num2 // 10

digit = num2 % 10
mult = mult * digit
num2 = num2 // 10

print('Сумма четырёхзначного числа равна', suma)
print('Произведение пятизначного числа равно', mult)
print()
