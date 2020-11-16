from math import *
# Вариант 23
x = int(input('Введите x: '))
n = int(input('Введите n: '))

# Выполнение через for
S = 0
for i in range(1, n):
    num = i * pow(x, i - 1)
    if i % 2 == 1:
        S = S + num
    else:
        S = S - num
print(S)

# Выполнение через while
S = 0
i = 1
while i < n:
    num = i * pow(x, i - 1)
    if i % 2 == 1:
        S = S + num
    else:
        S = S - num
    i = i + 1
print(S)
