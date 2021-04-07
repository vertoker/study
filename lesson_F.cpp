#include <iostream>

using namespace std;

int DaysInMonth(int month, int year){
	if(month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12){
		return 31;
	}
	else if(month == 4 || month == 6 || month == 9 || month == 11){
		return 30;
	}
	else if(month == 2){
		if (year % 4 > 0){
			return 28;
		}
		else if (year % 100 > 0){
			return 29;
		}
		else if (year % 400 > 0){
			return 28;
		}
		else{
			return 29;
		}
	}
	else{
		return 31;
	}
}

int main(){
	int d, m, y;
	//cout << "Input data:";
	cin >> y >> m >> d;
	int daysInMonth = DaysInMonth(m, y);
	if(y <= 1900 || y >= 2101 || m <= 0 || m > 12 || d <= 0 || d > daysInMonth){
		if(y <= 1900 || y >= 2101){
			cout << "Year must be in XX-XXI century";
		}
		if(m <= 0 || m > 12){
			cout << "\nWrong month";
		}
		if(d <= 0 || d > daysInMonth){
			cout << "\nWrong day";
		}
	}
	else{
		m -= 2;
		if(m <= 0){
			m += 12;
			y--;
		}
		cout << (m * 83 / 32 + d + y + y / 4 - y / 100 + y / 400) % 7;
	}
	return 0;
}
