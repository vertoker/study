#include <iostream>
#include <cmath>
using namespace std;

int main(){
	int a, y, z;
	cout << "Write a in radiants: ";
	cin >> a;
	y=cos(a)+ cos(a*2)+cos(a*6)+cos(a*7);
	z=4*cos(a/2)*cos(5/2*a)*cos(4*a);
	cout << "Z= " << z << ";\nY= " << y;
}
