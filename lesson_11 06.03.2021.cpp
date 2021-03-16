#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

void coutA2B(int a, int b){
	cout << a << endl;
	if(b - a > 0){
		coutA2B(a + 1, b);
	}
	else if(b - a < 0){
		coutA2B(a - 1, b);
	}
}

int main() {
	int a, b;
	cout << "input A: ";
	cin >> a;
	cout << "input B: ";
	cin >> b;
	
	coutA2B(a, b);
	return 0;
}
