#include <iostream>
using namespace std;
int main() {
	double v = 2;
	double result = (v + 1) * 2;
	cout << "result: " << result << " expected result : 6" << endl;
	result = (v + 1) * (v + 2) * 2;
	cout << "result: " << result << " expected result : 24" << endl;
	result = (v - 1) * v + 2 * 2;
	cout << "result: " << result << " expected result : 6" << endl;
	result = (v + v) * (v + v) * 2;
	cout << "result: " << result << " expected result : 32" << endl;
	result = (int)v % 2 * (v + 2 * 2);
	cout << "result: " << result << " expected result : 0" << endl;
	return 0;
}
