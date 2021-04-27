#include <iostream>
#include <iomanip>
#include <cmath>

using namespace std;

int main(){
	const int MAXHOURS = 24, MAXMINUTES = 60;
	struct Time {
		int hour;
		int minute;
	};
	
	Time t;
	int actionTime, power;
	cin >> t.hour >> t.minute >> actionTime;
	
	if (t.minute < 0 || t.minute >= MAXMINUTES || t.hour < 0 || t.hour >= MAXHOURS){
		cout << "Incorrect time";
	}
	else{
		t.minute += actionTime;
		power = t.minute / MAXMINUTES;
		t.minute -= power * MAXMINUTES;
		t.hour += power;
		power = t.hour / MAXHOURS;
		t.hour -= power * MAXHOURS;
		cout << t.hour / 10 << t.hour % 10 << ":" << t.minute / 10 << t.minute % 10;
	}
	
	return 0;
}
