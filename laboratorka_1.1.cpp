#include <iostream>
#include <cmath>
using namespace std;

//Вариант №22
int main() {
	double a, y, z;
	cout << "print a: ";
	cin >> a;
	
	y = (sin(2 * a) + sin(5 * a) - sin(3 * a)) / (cos(a) + 1 - 2 * pow(sin(2 * a), 2));
	z = 2 * sin(a);
	cout << y << endl << z;
	return 0;
}
