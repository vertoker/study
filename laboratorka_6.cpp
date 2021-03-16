#include <iostream>
#include <cmath>
#include <iomanip>
#include <cstdio>
using namespace std;

//Вариант №22
int main() {
	double start, stop, step;
	cout << "print start: ";
	cin >> start;
	cout << "print stop: ";
	cin >> stop;
	cout << "print step: ";
	cin >> step;
	
	cout << setw(8) << "x";
	cout << setw(8) << "y" << endl;
	for(double x = start; x <= stop; x += step){
		double y;
		if(x < -9){
			y = 0;
		}
		else if(x < -6){
		// y = sqrt(r^2 - (x - a)^2) + b
			y = -sqrt(9 - pow(x + 6, 2));
		}
		else if(x <= -3){
			y = x + 3;
		}
		else if(x <= 0){
			y = sqrt(9 - pow(x, 2));
		}
		else if(x <= 3){
			y = 3 - x;
		}
		else if(x <= 5){
			y = 7.5 - 1.5 * x;
		}
		else if(x <= 9){
			y = 0.75 * x - 3.75;
		}
		else{
			y = 3;
		}
		cout << setw(8) << fixed << setprecision(2) << x;
		cout << setw(8) << setprecision(3) << y << endl;
	}
	return 0;
}
