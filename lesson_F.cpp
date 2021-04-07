#include <iostream>

using namespace std;

int main(){
	int d, m, y;
	//cout << "Input data:";
	cin >> y >> m >> d;
	if(y <= 1900 || y >= 2101 || m <= 0 || m > 12 || d <= 0 || d > 31){
		if(y <= 1900 || y >= 2101){
			cout << "Year must be in XX-XXI century";
		}
		if(m <= 0 || m > 12){
			cout << "\nWrong month";
		}
		if(d <= 0 || d > 31){
			cout << "\nWrong day";
		}
	}
	else{
		m -= 2; // 1
		if(m <= 0){ // 2
			m += 12;
			y--;
		}
		m = (m * 83) / 32; // 3 +
		m += d; // 4 +
		m += y; // 5 +
		m += y / 4; // 6 +
		m -= y / 100; // 7 +
		m += y / 400; // 8
		m = m % 7; //
		cout << m;
	}
	return 0;
}
