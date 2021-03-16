#include <iostream>
#include <cmath>
using namespace std;

double sum(int n){
	if(n > 0){
		return sum(n - 1) + 10.8 * abs(cos(pow(n, 2) / 1.13)) * sin(n + 1.4);
	}
	return 0;
}

double sum2(int n){
	double x = 0;
	for(int i = 1; i <= n; i++){
		x += 10.8 * abs(cos(pow(i, 2) / 1.13)) * sin(i + 1.4);
	}
	return x;
}

//Вариант №22
int main() {
	cout << "Recursion: " << sum(10) << endl;
	cout << "Not recursion: " <<sum2(10);
	return 0;
}
