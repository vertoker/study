#include <iostream>
#include <cmath>
using namespace std;

//Вариант №22
int main() {
	double x, n, result;
	cout << "print x: ";
	cin >> x;
	cout << "print n: ";
	cin >> n;
	
	result = n * pow(x, n - 1);
	cout.setf(ios::fixed);
	cout.setf(ios::showpoint);
	cout.precision(3);
	cout << "derivated from x to the power of n equals " << result;
	return 0;
}
