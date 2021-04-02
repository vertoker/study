#include <iostream>

using namespace std;

int factorial(int);

int main(){
	int n;
	int result = factorial(n);
	cout << "writ facktorial: " << n << " pleas"<< endl;
	cin >> n;
	return 0;
}

int factorial(int n){
	if(n>1){
		return n *factorial(n-1);
	}
	cout << n;
	return 0;
}
