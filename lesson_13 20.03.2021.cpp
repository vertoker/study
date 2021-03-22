#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

bool InIP(int n){
	return 0 <= n && n <= 255;
}

int main() {
	int n1, n2, n3, n4;
	cin >> n1 >> n2 >> n3 >> n4;
	
	if(InIP(n1) && InIP(n2) && InIP(n3) && InIP(n4)){
		cout << n1 << "." << n2 << "." << n3 << "." << n4 << endl;
	}
	if(!InIP(n1)){
		cout << "First is not valid" << endl;
	}
	if(!InIP(n2)){
		cout << "Second is not valid" << endl;
	}
	if(!InIP(n3)){
		cout << "Third is not valid" << endl;
	}
	if(!InIP(n4)){
		cout << "Fourth is not valid" << endl;
	}
}
