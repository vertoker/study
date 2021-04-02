#include <iostream>

using namespace std;

int main(){
	unsigned long long x=1;
	int n;
	cin >> n;
	if(n>=0 && n<=63){
		for(int i=0; i<n; i++){
			x=x*2;
		}
		cout << x;
	}else{
		cout << "Wrong number";
	}
	return 0;
}
