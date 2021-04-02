#include <iostream>
#include <cmath>
using namespace std;

int factorial(int i){
	if (i == 1){
		return 1;
	}
	return i * factorial(i - 1);
}

int main() {
	double s = 1, eps = 0.001, term = 5 * eps, x;
	
	do{
		cout << "Input -1000 < x < 1000: ";
		cin >> x;
	} while(abs(x) >= 1000);
	
	cout << "e = " << pow(M_E, x) << endl;
	for(int k = 1; abs(term) > eps; k++){
		term = pow(x, k) / factorial(k);
		s += term;
		cout << s << endl;
	}
	
	cout << "s = " << s << endl;
	return 0;
}
