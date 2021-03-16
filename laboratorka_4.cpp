#include <iostream>
#include <cmath>
using namespace std;

//Вариант №22
int main() {
	//Ввод основной информации
	double e = 0.0001, a0, a1, fact = 2;
	int n = 2;
	
	//Выполнение через do while
	a1 = pow(2, n) * fact / pow(n, n);
	do{
		n++;
		a0 = a1;
		fact *= n;
		a1 = pow(2, n) * fact / pow(n, n);
		//cout << abs(a1 - a0) << "\n";
	}
	while(abs(a1 - a0) > e);
	
	//Вывод через do while
	cout << "a in n = " << a1 << "\n";
	cout << "a in (n-1) = " << a0 << "\n";
	cout << "n = " << n << "\n";
	
	//Выполнение через while
	n = 2; fact = 2;
	a1 = pow(2, n) * fact / pow(n, n);
	while(abs(a1 - a0) > e){
		n++;
		a0 = a1;
		fact *= n;
		a1 = pow(2, n) * fact / pow(n, n);
		//cout << abs(a1 - a0) << "\n";
	}
	
	//Вывод через while
	cout << "a in n = " << a1 << "\n";
	cout << "a in (n-1) = " << a0 << "\n";
	cout << "n = " << n << "\n";
	return 0;
}
