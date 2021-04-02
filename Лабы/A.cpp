#include <iostream>
#include <cmath>
using namespace std;

int main(){
	int a, b;
	const double E=0.000001, one=1;
	//cout << "Put a: ";
	cin >> a;
	//cout << "Put b: ";
	cin >> b;
	
	if (abs(one/a-one/b)<E){
		cout << "Results are equal (by 0.000001 epsilon)";
	}else{
		cout << "Results are not equal (by 0.000001 epsilon)";	
	}
	
}
