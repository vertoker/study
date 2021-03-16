#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

int main() {
	double num1 = 2.3;
	double num2 = 2.3;
	double num3 = 2.123456;
	double num4 = 2.123456;
	double num5 = 2.123456;
	
	cout << num1 << endl;
	cout.precision(2);
	cout << fixed << num2 << endl;
	cout.precision(6);
	cout << num3 << endl;
	cout.precision(2);
	cout << num4 << endl;
	cout.precision(0);
	cout << num5;
	
	return 0;
}
