#include <iostream>
#include <cmath>
using namespace std;

void MinusFractions(int n1, int d1, int n2, int d2){
	int numerator = abs(n1 * d2 - n2 * d1);//Числитель
	int denominator = abs(d1 * d2);//Знаменатель
    int counter = numerator;
    
    while(counter > 0){
        if(numerator % counter == 0 && denominator % counter == 0){
        	if(n1 * d2 - n2 * d1 < 0 || d1 * d2 < 0){
				cout << "-";
			}
			cout << numerator / counter << "|" << denominator / counter << endl;
            break;
        }
        counter--;
    }
}

//Вариант №22
int main() {
	int n1, d1, n2, d2;
	cout << "Enter first numerator: ";
	cin >> n1;
	cout << "Enter first denominator: ";
	cin >> d1;
	cout << "Enter second numerator: ";
	cin >> n2;
	cout << "Enter second denominator: ";
	cin >> d2;
	
	MinusFractions(n1, d1, n2, d2);
	return 0;
}
