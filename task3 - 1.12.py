n = int(input())
a = []
for i in range(n):
    a.append([])
    for j in range(n):
        a[i].append(int(input()))

maximum = a[0][0]
for i in range(n):
    for j in range(n):
        if (maximum < a[i][j] and j >= i and j >= n - i - 1) or (j <= i and j <= n - i - 1 and maximum < a[i][j]):
            maximum = a[i][j]

for i in range(n):
    for j in range(n):
        if i == j:
            if a[i][j] > maximum:
                maximum = a[i][j];
        if (i + j) == (n - 1):
            if a[i][j] > maximum:
                maximum = a[i][j];

print(maximum)