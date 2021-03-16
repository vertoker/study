#include <iostream>
using namespace std;

//Вариант №22
int main() {
	int num;
	cout << "print 4-digital number: ";
	cin >> num;
	
	int numMod = num;
	int reverse = 0;
    while(numMod)
    {
        reverse = 10 * reverse + numMod % 10;
        numMod /= 10;
    }
    
	if (num == reverse) {
		cout << "This is palindrome";
	} else {
		cout << "This isn't palindrome";
	}
	return 0;
}
