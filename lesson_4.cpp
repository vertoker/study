#include <iostream>
using namespace std;

int main() {
	int a, b, x, y, s1, s2;
	cin >> a >> b >> x >> y;
	s1 = a + x;
	s2 = b + y;
	if(s1 == s2){
		cout << s1;
	}
	else{
		if(s1 < s2){
			cout << s1;
		}
		else{
			cout << s2;
		}
	}
	return 0;
}
