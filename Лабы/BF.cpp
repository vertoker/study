#include <iostream>
#include <cmath>
using namespace std;

int main(){
	int b1, b2, b3, pas, need;
	bool f;
	cin >> b1 >> b2>> b3;
	need = (b1 +b2+b3)/3;
	pas = (abs(b1-need) + abs(b2-need)+abs(b3-need)/2);
	f=(b1+b2+b3)%3;
	(f == true) and cout << "IMPOSSIBLE";
	(f == false) and cout << pas;
	return 0;
}
