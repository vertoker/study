#include <iostream>

using namespace std;

int main(){
	double valPrice, tax;
	cin >> valPrice >> tax;
	
	if(valPrice < 0 || tax <= 0 || tax >= 100){
		if(valPrice < 0){
			cout << "Price can not be less then 0" << endl;
		}
		if(tax <= 0){
			cout << "Tax can not be less or equal 0" << endl;
		}
		if(tax >= 100){
			cout << "Tax can not be more or equal 100" << endl;
		}
	}
	else{
		double netPrice = valPrice * 100 / (100 + tax);
		cout << "Net price: "<< netPrice << endl;
		cout << "Tax value: " << valPrice - netPrice << endl;
	}
}
