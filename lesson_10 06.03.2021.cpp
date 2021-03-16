#include <iostream>
#include <sstream>
#include <math.h>
#include <string>
using namespace std;

void outputFrom1ToN(int n){
	if(n > 1){
		outputFrom1ToN(n - 1);
	}
	cout << n << endl;
}

int cinNaturalNum(int n){
	if (n < 1){
		cin >> n;
		return cinNaturalNum(n);
	}
	return n;
}

int main() {
	cout << "input num: ";
	int n;
	cin >> n;
	n = cinNaturalNum(n);
	
	outputFrom1ToN(n);
	return 0;
}
