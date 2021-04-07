#include <iostream>

using namespace std;

int main(){
	int year;
	cin >> year;
	if(year >= 1900 && year <= 2100){
		int a = year % 19;
		int b = year % 4;
		int c = year % 7;
		int d = (a * 19 + 24) % 30;
		int e = (2 * b + 4 * c + 6 * d + 5) % 7;
		
		if(d + e < 10){
			cout << "March " << d + e + 22 << endl;
		}
		else{
			cout << "April " << d + e - 9 << endl;
		}
	}
	else{
		cout << "Year must be XX-XXI century";
	}
	return 0;
}
