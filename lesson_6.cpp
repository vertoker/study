#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

int main() {
	double x, y;
 	cin >> x;
 	
 	double x2 = pow(x, 2);
 	double p1 = pow(M_PI, 2) * (x2 + 1.0 / 2.0);
 	double p2 = pow(M_PI, 2) * pow(x2 - 1.0 / 2.0, 2);
 	y = x2 / p1 * (1 + x2 / p2);
 	
 	cout.setf(ios::fixed);
	cout.setf(ios::showpoint); 
 	cout.precision(5);
 	cout << y;
	return 0;
}
