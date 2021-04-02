#include <iostream>
using namespace std;

int main(){
	int a;
	//cout << "Write year: ";
	cin >> a;
	
	if (a < 1582){
		cout << "Year less than 1582";
	}
	else if(a % 4 == 0 && (a % 100 != 0 || (a % 100 == 0 && a % 400 == 0))){
		cout << "Leap year";
	}
	else{
		cout << "Common year";
	}
	return 0;
}
