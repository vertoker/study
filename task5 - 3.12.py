n = int(input())
a = [[*map(int, input().split())] for _ in range(n)]

w = n - 1

for i in range(n):
    for j in range(n):
        if i == j:
            q = a[i + w][j]
            a[i + w][j] = a[i][j]
            a[i][j] = q
            w = w - 2

for i in range(n):
    for j in range(n):
        print(a[i][j], end = " ")
    print()