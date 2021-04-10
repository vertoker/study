#include <iostream>
#include <iomanip>
#include <cmath>
#include <cstdlib>
#include <ctime>
using namespace std;

double f1(double x){
	return 1 / sqrt(1 - x * x);
}

double f2(double x){
	return sin(x) * sin(2 * x) * sin(3 * x);
}

double trap(double a, double b, int N, double(*f)(double x)){
	double h = (b - a) / N, x = a, s = 0;
	for(int i = 1; i < N; i++){
		s += f(x);
		x += h;
	}
	return s * h;
}

//Вариант №22
int main() {
	cout << "a: " << trap(-0.5, 0.5, 100, f1) << endl;
	cout << "b: " << trap(0, M_PI / 2, 200, f2) << endl;
	return 0;
}
