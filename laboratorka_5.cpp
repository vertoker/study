#include <iostream>
#include <cmath>
#include <math.h>
using namespace std;

long double fact(int N)
{
    if (N < 0) return 0;
    if (N == 0) return 1;
    return N * fact(N - 1);
}

int main() {
	long double s = 0, eps = 0.001, term = eps, x;
	int counter = 0;
	
	do{
		cout << "Input -1000 < x < 1000: ";
		cin >> x;
	} while(x >= 1000 || x <= -1000);
	
	cout << "e^x = " << exp(x) << endl;
	
	while(abs(term) >= eps){
		term = pow(x, counter) / fact(counter);
		s += term;
		counter++;
	}
	
	cout << "s = " << s << endl;
	return 0;
}
