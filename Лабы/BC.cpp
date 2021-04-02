#include <iostream>

using namespace std;

int main(){
	int m, n, k, a, b;
	//cout << "M, N, K: "
	cin >> m >> n >> k;
	int up (((n-1)/k+1)*k);
	int down (((n-1)%k)*2);
	if((n-1)%k==0){
	cout << '0';
	}
	else{
		if(up-n+1<=down && m>=up){
		cout << (up-n+1)*100;
	}else{
		down*100;
	}
}}
