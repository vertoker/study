l = int(input())
numberList = []
for n in range(l):
	numberList.append(1)
	if n > 1:
		for m in range(n - 1, 0, -1):
			numberList[m] = numberList[m - 1] + numberList[m]
	print(" ".join([str(item) for item in numberList]))