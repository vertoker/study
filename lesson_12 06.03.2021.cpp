#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

bool equals(float a, float b){
	float e = 0.000001;
	float diff = a - b;
   	return abs(diff) < e;
}

int main() {
	float a, b;
	cout << "input A: ";
	cin >> a;
	cout << "input B: ";
	cin >> b;
	
	cout << "Results are " << (equals(a, b) ? "" : "not ") << "equal (by 0.000001 epsilon)";
	return 0;
}
