#include <iostream>
#include <cmath>

using namespace std;

int main(){
	int notation, lb;
	double meter, inch, total_len;
	const double one_inch=39.37008;
	cin >> notation;
	if (notation<=0){
		//cout << "Meter: ";
		cin >> meter;
		if (notation<0){
			cout <<"Wrong metric system";
		}else {
			total_len=meter*one_inch;
			cout << int(total_len/12) << "\'" << int(floor(total_len))%12+total_len-floor(total_len)<< "\'";
		}
	}else{
		//cout << "Empire: ";
		cin >> lb >> inch;
		if(notation>1){
			cout <<"Wrong metric system";
		}else{
		cout << (lb*12+inch)/one_inch<<"m";
	}}
	return 0;
}
