#include <iostream>
#include <cmath>
using namespace std;

int main() {
	int m, n, i;
	cin >> n >> m;
	int c = n, t = -1;
	
	int *a = new int[n];
	for (i = 0; i < n; i++) {
		a[i] = i + 1;
	}
	
	while(c > 1) {
		
	}
	a[t] = 0;
	c--;
	for(int i = 0; i < n; i++)
		if(a[i] != 0) {
			cout << i + 1;
			break;
		}
	delete[] a;
	return 0;
}
