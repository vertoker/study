#include <iostream>

using namespace std;

int main(){
	unsigned long p;
	cin >> p;
	int bin =0;
	for(unsigned long i=1; i<=p; i){
		if(p%2==1){
			bin=bin+1;
		}
		p=p/2;
	}
	cout << bin;
	return 0;
}
