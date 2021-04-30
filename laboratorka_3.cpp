#include <iostream>
using namespace std;

//Вариант №22
int main() {
	int day;
	cout << "Enter day of week: ";
	do{
		cin >> day;
	}
	while(day > 7 || day < 1);
	
	if(day == 1){
		cout << "1 - nothing" << endl;
		cout << "2 - nothing" << endl;
		cout << "3 - nothing" << endl;
		cout << "4 - Object Oriented Programming" << endl;
		cout << "5 - Basics of calculating systems" << endl;
	}
	else if(day == 2){
		cout << "1 - C++ Programmng" << endl;
		cout << "2 - C++ Programmng" << endl;
		cout << "3 - English" << endl;
		cout << "4 - English" << endl;
		cout << "5 - nothing" << endl;
	}
	else if(day == 3){
		cout << "1 - nothing" << endl;
		cout << "2 - nothing" << endl;
		cout << "3 - 1C Systems" << endl;
		cout << "4 - C++ Programmng" << endl;
		cout << "5 - Basics of calculating systems" << endl;
	}
	else if(day == 4){
		cout << "1 - 1C Systems" << endl;
		cout << "2 - 1C Programming" << endl;
		cout << "3 - C++ Programmng" << endl;
		cout << "4 - C++ Programmng" << endl;
		cout << "5 - Basics of calculating systems" << endl;
	}
	else if(day == 5){
		cout << "1 - nothing" << endl;
		cout << "2 - C++ Programmng" << endl;
		cout << "3 - 1C Programmng" << endl;
		cout << "4 - C++ Programmng" << endl;
		cout << "5 - Basics of calculating systems" << endl;
	}
	else if(day == 6){
		cout << "1 - nothing" << endl;
		cout << "2 - nothing" << endl;
		cout << "3 - Basics of calculating systems" << endl;
		cout << "4 - Mathematics" << endl;
		cout << "5 - nothing" << endl;
	}
	else {
		cout << "1 - nothing" << endl;
		cout << "2 - nothing" << endl;
		cout << "3 - nothing" << endl;
		cout << "4 - nothing" << endl;
		cout << "5 - nothing" << endl;
	}
	
	return 0;
}
