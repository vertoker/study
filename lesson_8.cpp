#include <iostream>
#include <math.h>
using namespace std;

int main() {
	bool answer;
	int value;
	cin >> value;
	
	answer = (value>=0 && value<10) || (value*2<20 && value-2>-2) || (value-1>1 && value/2<10) || value==111;
	cout << (answer ? "THAT'S TRUE :)" : "THAT'S NOT TRUE :(") << endl;
	return 0;
}
