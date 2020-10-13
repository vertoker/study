import math
#1
print('Три числа:', 10, 5, 24, sep = ' ')

print()

# 2
print('Три числа: ', 103, ', ', 25, ', ', 724, sep = '')

print()

# 3
print(1, '\n', 2, '\n', 3, sep = '')

print()

# 4
print('%.3f'% math.pi)

print()

# 5
print('%8.0f%8.0f'% (124, 13))
print('%8.0f%8.0f'% (56, 355))
print('%8.0f%8.0f'% (587, 8))

print()

# 6
print('%9.2f%9.2f'% (1.24, 13.52))
print('%9.3f%9.1f'% (3.567, -355.1))
print('%9.1f%9.2f'% (8.2, 9.18))

print()

# 7
print('%10.3f%10.3f'% (7.24, -43.52))
print('%10.3f%10.3f'% (23.5, 55.107))
print('%10.3f%10.3f'% (88.203, -769.8))

print('===================================')

# Задание 2

print('Задание 2')

print()

# 4
print(format(math.pi, '0.3f'))

print()

# 5
print(format(124, '8.0f'), format(13, '8.0f'))
print(format(56, '8.0f'), format(355, '8.0f'))
print(format(587, '8.0f'), format(8, '8.0f'))

print()

# 6
print(format(1.24, '9.2f'), format(13, '9.2f'))
print(format(3.567, '9.3f'), format(-355.1, '9.1f'))
print(format(8.2, '9.1f'), format(9.18, '9.2f'))

print()

# 7
print(format(7.24, '10.3f'), format(-43.52, '10.3f'))
print(format(23.5, '10.3f'), format(55.107, '10.3f'))
print(format(88.203, '10.3f'), format(-769.8, '10.3f'))

