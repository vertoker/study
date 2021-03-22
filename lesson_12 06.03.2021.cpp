#include <iostream>
#include <iomanip>
#include <math.h>
using namespace std;

bool Equals(double a, double b){
	double e = 0.000001;
	double diff = a - b;
   	return fabs(diff) < e;
}

int main() {
	int a, b;
	cin >> a >> b;
	double da = 1.0 / a;
	double db = 1.0 / b;
	bool isEquals = Equals(da, db);
	
	cout << da << " " << db << " Results are " << (isEquals ? "" : "not ") << "equal (by 0.000001 epsilon)";
	return 0;
}
