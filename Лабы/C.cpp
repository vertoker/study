#include <iostream>

using namespace std;

int main(){
	int a, b;
	bool leapA;
	cout << "Write year: ";
	cin >> a;
	if (a<1582){
		cout<< "Year less than 1582";
	}else{
		if(a%4!=0){
			leapA=false;
		}else{
			if(a%100!=0){
				leapA=true;
			}else{
				if(a%100!=0){
					leapA=false;
				}else{
					leapA=true;
				}
			}
		}
			if(leapA){
				cout << "Leap year";
			}else{
				cout << "Common year";

	}
	}
	return 0;
}
