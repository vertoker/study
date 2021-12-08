#include <iostream>
#include <cmath>
using namespace std;

double factorial(double N) {
	if (N < 0)
		return 0;
	if (N == 0)
		return 1;
	return N * factorial(N - 1);
}

double BinomialCoefficient(double n, double m) {
	return factorial(n) / (factorial(m) * factorial(n - m));
}

int main() {
    int n, arraySize, num;
    cin >> n;
    arraySize = n + 1;
    int array[arraySize];
    
    for (int i = 0; i < arraySize; i++) {
        array[i] = BinomialCoefficient(n, i);
        cout << array[i];
        if (i < arraySize - 1) {
            cout << ", ";
        }
    }
    return 0;
}