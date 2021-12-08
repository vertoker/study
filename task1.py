from math import *

def BinomialCoefficient(n:int, m:int):
	return factorial(n) / (factorial(m) * factorial(n - m))

n = int(input())
numberList = []
for m in range(n + 1):
	numberList.append(int(BinomialCoefficient(n, m)))
print(", ".join([str(item) for item in numberList]))