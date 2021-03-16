#include <iostream>
using namespace std;

//Вариант 22
int main() {
	double a, b, c, F;
	cout << "print a: ";
	cin >> a;
	cout << "print b: ";
	cin >> b;
	cout << "print c: ";
	cin >> c;
	
	double condition = a + b + c;
	double temp, p1, p2;
	if(condition < 45){
		if (a > b){
			temp = a;
		}
		else{
			temp = b;
		}
		if (temp > c){
			p1 = temp;
		}
		else{
			p1 = c;
		}
		
		if (a < b){
			p2 = a;
		}
		else{
			p2 = b;
		}
		
		F = p1 / p2;
	}
	else if(condition <= 55){
		if (a > b){
			temp = a;
		}
		else{
			temp = b;
		}
		if (temp > c){
			p1 = temp;
		}
		else{
			p1 = c;
		}
		
		if (a < b){
			temp = a;
		}
		else{
			temp = b;
		}
		if (temp < c){
			p2 = temp;
		}
		else{
			p2 = c;
		}
		
		F = p1 + p2;
	}
	else{
		if (a < b){
			temp = a;
		}
		else{
			temp = b;
		}
		if (temp < c){
			p1 = temp;
		}
		else{
			p1 = c;
		}
		
		if (a < c){
			p2 = a;
		}
		else{
			p2 = c;
		}
		
		F = p1 / p2;
	}
	cout << F;
	return 0;
}
