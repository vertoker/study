from math import *

def BinomialCoefficient(n:int, m:int):
	return factorial(n) / (factorial(m) * factorial(n - m))

l = int(input())
for n in range(l):
	numberList = []
	for m in range(n + 1):
		numberList.append(int(BinomialCoefficient(n, m)))
	print(" ".join([str(item) for item in numberList]))