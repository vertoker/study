n = int(input())
a = []
for i in range(n):
    a.append([])
    for j in range(n):
        a[i].append(int(input()))

top = right = down = left = 0

for i in range(n):
    for j in range(n):
        if i != j and ((i + j) != (n - 1)):
            if j > i and (j < (n - 1 - i)):
                top = top + a[i][j]
            if j > i and (j > (n - 1 - i)):
                right = right + a[i][j]
            if j < i and (j > (n - 1 - i)):
                down = down + a[i][j]
            if j < i and (j < (n - 1 - i)):
                left = left + a[i][j]

print("top:", top)
print("right:", right)
print("down:", down)
print("left:", left)

