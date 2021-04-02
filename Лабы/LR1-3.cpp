#include <iostream>

using namespace std;

int main(){
	float a;
	int b, c, d, e, f, n;
	setlocale(LC_ALL, "rus");
	cout << "¬ведите действительное число в виде nnn.ddd: ";
	cin >> a;
	a=a*1000;
	b=int(a);
	c=int(a);
	d=int(a);
	e=int(a);
	f=int(a);
	n=int(a);
	cout << a << " " << b << " " << c << " " << d << " " << f << " " << n;
}
