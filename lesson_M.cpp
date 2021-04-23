#include <iostream>
#include <cmath>
using namespace std;

int main() {
	int m, n, i;
	cin >> n >> m;
	int nc = n, mc = 0;
	
	int *a = new int[n];
	for (i = 0; i < n; i++) {
		a[i] = i + 1;
	}
	
	while(nc > 1) {
		for(int i = 0; i < m; i++) {
			mc++;
			if (mc == nc + 1){
				mc = 0;
			}
		}
		
		for(int i = 0; i < n; i++) {
			if(a[i] != 0) {
				cout << i + 1;
				break;
			}
		}
		
		for(int i = 0; i < n; i++) {
			if(a[i] != 0) {
				cout << i + 1;
				break;
			}
		}
		nc--;
	}
	
	for(int i = 0; i < n; i++) {
		if(a[i] != 0) {
			cout << i + 1;
			break;
		}
	}
	delete[] a;
	return 0;
}
