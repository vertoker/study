#include <iostream>
#include <cmath>
using namespace std;

//Вариант №22
int main() {
	const double A = 1.45645, B = 5.2342354234;
	double x, y;
	cout << "print x: ";
	cin >> x;
	cout << "print y: ";
	cin >> y;
	
	double f1 = pow(log(abs(pow(x, 3) + pow(y, 3))), 1.0 / 3.0);
	double f2 = sin(x * sqrt(A * y));
	double f3 = cos(y * sqrt(B * x));
	double F = f1 / f2 + f3;
	cout << "F(x, y) = " << F;
	return 0;
}
