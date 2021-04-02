#include <iostream>

using namespace std;

int main(){
	int a, b;
	//cout << "Input 0c: ";
	cin >> a;
	if (a>0){
		while (a>1){
			if (a%2==0){
				a/=2;
				b++;
				cout<<a<< endl;
			}else{
				a=3*a+1;
				b++;
				cout<<a<<endl;
			}
		}
		cout<<"steps = " <<b;
	}else {
		cout<<"Wrong number";
	}
	return 0;
}
